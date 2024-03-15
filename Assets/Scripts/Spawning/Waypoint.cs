using UnityEngine;

namespace Spawning
{
    public class Waypoint : MonoBehaviour
    {
        public bool isFirstWaypoint = false;
        private void OnDrawGizmos()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = isFirstWaypoint ? Color.green : Color.blue;
            Gizmos.DrawSphere(transform.position, .2f);
        }
    }
}
