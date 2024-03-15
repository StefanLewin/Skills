using System.Collections.Generic;
using System.Linq;
using EditorHelper;
using Enemy.Enums;
using UnityEngine;

namespace Spawning
{
    public class NpcSpawnPoint : MonoBehaviour
    {
        [SerializeField] protected GameObject npcPrefab;
        [SerializeField] protected IdleMoveMode idleMoveMode;
        [SerializeField] private Waypoint waypointPrefab;
        [SerializeField] private GameObject wayPointContainer;

        private List<Waypoint> _waypoints;

        private void Awake()
        {
            _waypoints = new List<Waypoint>();
            CreateWaypoints();
        }

        /// <summary>
        /// Create either standard, or custom waypoints.
        /// </summary>
        private void CreateWaypoints()
        {
            if (_waypoints.Count > 0) return;

            switch (idleMoveMode)
            {
                case IdleMoveMode.Static:
                    break;
                case IdleMoveMode.Horizontal:
                    Waypoint hor1 = Instantiate(waypointPrefab, wayPointContainer.transform);
                    Waypoint hor2 = Instantiate(waypointPrefab, wayPointContainer.transform);
                    
                    hor1.transform.position += Vector3.left;
                    hor2.transform.position += Vector3.right;
                    
                    _waypoints.Add(hor1);
                    _waypoints.Add(hor2);
                    break;
                case IdleMoveMode.Vertical:
                    Waypoint ver1 = Instantiate(waypointPrefab, wayPointContainer.transform);
                    Waypoint ver2 = Instantiate(waypointPrefab, wayPointContainer.transform);
                    
                    ver1.transform.position += Vector3.up;
                    ver2.transform.position += Vector3.down;
                    
                    _waypoints.Add(ver1);
                    _waypoints.Add(ver2);
                    break;
                case IdleMoveMode.Diamond:
                    Waypoint dia1 = Instantiate(waypointPrefab, wayPointContainer.transform);
                    Waypoint dia2 = Instantiate(waypointPrefab, wayPointContainer.transform);
                    Waypoint dia3 = Instantiate(waypointPrefab, wayPointContainer.transform);
                    Waypoint dia4 = Instantiate(waypointPrefab, wayPointContainer.transform);
                    
                    dia1.transform.position += Vector3.up;
                    dia2.transform.position += Vector3.right;
                    dia3.transform.position += Vector3.down;
                    dia4.transform.position += Vector3.left;
                    
                    _waypoints.Add(dia1);
                    _waypoints.Add(dia2);
                    _waypoints.Add(dia3);
                    _waypoints.Add(dia4);
                    break;
                case IdleMoveMode.Custom:
                    for (var i = 0; i < wayPointContainer.transform.childCount; i++)
                        _waypoints.Add(wayPointContainer.transform.GetChild(i).GetComponent<Waypoint>());
                    break;
                default:
                    break;
            }    
        }

        /// <summary>
        /// Spawn a npc
        /// </summary>
        public virtual void Spawn()
        {
            var npc = Instantiate(this.npcPrefab, this.transform);
            var waypointTransforms = _waypoints.Select(element => element.transform).ToList();
            npc.GetComponent<Enemy.Enemy>().Waypoints = waypointTransforms;
        }
        
        /// <summary>
        /// Draw helpers in scene view.
        /// </summary>
        protected void OnDrawGizmos()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, .3f);

            //Return, if there are no custom waypoints
            if (wayPointContainer.transform.childCount <= 0)
                return;
            
            var wpCount = wayPointContainer.transform.childCount;
            
            for (var i = 0; i < wpCount - 1; i++)
            {
                Transform firstWp = wayPointContainer.transform.GetChild(i).transform;
                Transform secondWp = wayPointContainer.transform.GetChild(i + 1).transform;

                //Mark first waypoint
                firstWp.GetComponent<Waypoint>().isFirstWaypoint = i == 0;
                
                //Draw arrow between two waypoints
                DrawArrow.ForGizmoTwoPoints(firstWp.position, secondWp.position);
            }

            //Draw last arrow between end- and start-waypoint
            DrawArrow.ForGizmoTwoPoints(wayPointContainer.transform.GetChild(wpCount - 1).position,
                wayPointContainer.transform.GetChild(0).position);
        }
    }
}
