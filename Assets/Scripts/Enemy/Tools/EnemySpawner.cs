using UnityEngine;

namespace Enemy.Tools
{
    public class EnemySpawner : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            for (var i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).GetComponent<EnemySpawnPoint>().SpawnEnemy();
            }
        }
    
    }
}
