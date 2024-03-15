using UnityEngine;

namespace Spawning
{
    public class EnemySpawnPoint : NpcSpawnPoint
    {
        private GameObject enemyObject;
        
        public override void Spawn()
        {
            enemyObject = Instantiate(this.npcPrefab, this.transform);
           //enemyObject.GetComponent<Enemy>()
        }
    }
}