using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();        

        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsWaypoint();
    }

    //Moves the enemy to the next waypoint in the list.
    private void MoveTowardsWaypoint()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position =
                Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}



//Gets the waypoints from the path by converting it into a list.
//RANT: I HAVE TO DO IT THIS WAY BECAUSE SOME IDOIT CHANGED THE WAY PREFABS WORK IN THE 
//PROJECT VIEW AND NO YOU CAN'TTTTTTT ACCESS THE CHILDREN OF A PREFAB IN PROJECT VIEW
//OR REFERENCE THEM IN OTHER PREFABS FOR SIMPLE THINGS LIKE LISTS
//ALSO IT'S CALLED GETCOMPONENTSINCHILDREN WHY THE FUCK IS IT ALSO GETTING THE FUCKING PARENT!!!!!!
//private void GetWaypoints()
//{
//    [SerializeField] GameObject path;
//    [SerializeField] List<Transform> waypoints;

//    waypoints = new List<Transform>(path.GetComponentsInChildren<Transform>());
//    waypoints.RemoveAt(0);
//}