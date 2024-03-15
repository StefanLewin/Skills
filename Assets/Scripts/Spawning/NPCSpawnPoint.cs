using Enemy.Enums;
using UnityEngine;

namespace Spawning
{
    public class NpcSpawnPoint : MonoBehaviour
    {
        [SerializeField] protected GameObject npcPrefab;
        [SerializeField] protected IdleMoveMode idleMoveMode;

        public virtual void Spawn()
        {
            Instantiate(this.npcPrefab, this.transform);
        }
        
        protected void OnDrawGizmos()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, .3f);
        }
    }
}
