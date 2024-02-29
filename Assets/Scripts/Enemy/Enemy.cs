using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private new Rigidbody2D rigidbody { get; set; }
    private EnemyState m_EnemyState;

    [SerializeField] private EnemyType type;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private string name;
    [SerializeField] private int health;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        rigidbody = this.transform.GetComponent<Rigidbody2D>();
        m_EnemyState = EnemyState.IDLE;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void Attack()
    {
        
    }
}

public enum EnemyState
{
    IDLE,
    HOSTILE
}
