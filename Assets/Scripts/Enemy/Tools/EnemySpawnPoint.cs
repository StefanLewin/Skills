using Scriptable_Objects;
using UnityEngine;

namespace Enemy.Tools
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;

        public void SpawnEnemy()
        {
            var newEnemy = Instantiate(this.enemyPrefab, this.transform);
        }
        
        private void OnDrawGizmos()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, .3f);
        }
    }
}
