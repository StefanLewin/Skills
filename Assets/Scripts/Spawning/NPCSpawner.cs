using UnityEngine;

namespace Spawning
{
    public class NpcSpawner : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            SpawnChildren();
        }

        protected void SpawnChildren()
        {
            for (var i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).GetComponent<NpcSpawnPoint>().Spawn();
            }
        }
    }
}
