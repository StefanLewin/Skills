using Scriptable_Objects;
using UnityEngine;

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [HideInInspector] public EnemyAttributes attributes;
    }
}