using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "Enemy/EnemyType")]
    public class EnemyAttributes : ScriptableObject
    {
        public string enemyName;
        public int health;
        public int speed;
        public int strength;
        public int attackCooldown;
        public int rangeOfAwareness;
    }
}
