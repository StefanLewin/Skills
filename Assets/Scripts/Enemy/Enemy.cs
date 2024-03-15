using System.Collections;
using System.Collections.Generic;
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

        public List<Transform> _waypoints;
        
        private float speed = 3f;

        private bool _waiting = false;
        private int _wayPointIndex;
        
        public List<Transform> Waypoints
        {
            get { return _waypoints;}
            set { _waypoints = new List<Transform>(value); }
        }

        protected virtual void Awake()
        {
            this.Rigidody = this.GetComponent<Rigidbody2D>();
        }

        protected virtual void FixedUpdate()
        {
            Move();
        }

        protected void Move()
        {
            if (_waypoints.Count == 0) return;
            if (_waiting) return;
            Transform wp = _waypoints[_wayPointIndex];
            
            if (Vector3.Distance(this.Rigidody.position, wp.position) < 0.1f)
            {
                _wayPointIndex = (_wayPointIndex + 1) % _waypoints.Count;
                StartCoroutine(Wait());
            }
            else
            {
                Vector2 direction = (wp.position - transform.position).normalized;
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