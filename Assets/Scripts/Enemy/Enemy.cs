using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Enemy.Enums;
using Scriptable_Objects;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected EnemyAttributes attributes;
        [SerializeField] protected Sprite idleSprite;
        [SerializeField] protected Sprite hostileSprite;
        protected EnemyState State;
        protected Rigidbody2D Rigidody;

        private Vector3 _horizontalPos1;
        private Vector3 _horizontalPos2;
        private Vector3 _verticalPos1;
        private Vector3 _verticalPos2;

        private Vector3 _startPosition;

        private List<Vector3> _waypoints;
        
        private float speed = 3f;

        private bool _waiting = false;
        private int _wayPointIndex;
        
        public List<Vector3> Waypoints
        {
            get{}
            set { _waypoints = new List<Vector3>(value); }
        }

        protected virtual void Awake()
        {
            this.Rigidody = this.GetComponent<Rigidbody2D>();
            
            
            _startPosition = this.transform.position;

            _horizontalPos1 = _startPosition + Vector3.left;
            _horizontalPos2 = _startPosition + Vector3.right;
            _verticalPos1 = _startPosition + Vector3.up;
            _verticalPos2 = _startPosition + Vector3.down;

            _waypoints = new List<Vector3>
            {
                _horizontalPos1,
                _horizontalPos2,
                _verticalPos1,
                _verticalPos2
            };
            
        }

        protected virtual void FixedUpdate()
        {
            Move();
        }

        protected void Move()
        {
            if (_waypoints.Count == 0) return;
            if (_waiting) return;
            var wp = _waypoints[_wayPointIndex];
            
            if (Vector3.Distance(this.Rigidody.position, wp) < 0.1f)
            {
                _wayPointIndex = (_wayPointIndex + 1) % _waypoints.Count;
                StartCoroutine(Wait());
            }
            else
            {
                Vector2 direction = (wp - transform.position).normalized;
                Rigidody.MovePosition(Rigidody.position + direction * (speed * Time.fixedDeltaTime));
            }
        }

        private IEnumerator Wait()
        {
            _waiting = true;
            yield return new WaitForSeconds(1.0f);
            _waiting = false;
        }
    }
}