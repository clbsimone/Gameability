using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    // Start is called before the first frame update
    public bool complete=false;
    [SerializeField] public int indexCar;
    [SerializeField] private Waypoints waypoints;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceTreshold=0.1f;

    private Transform currentWaypoint;

    private Transform prevWaypoint;
    void Start()
    {
        //posizione iniziale al primo waypoint
        currentWaypoint=waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //punto al prossimo waypoint ma non lo sposto
        currentWaypoint=waypoints.GetNextWaypoint(currentWaypoint);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCar()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceTreshold)
        {
            prevWaypoint = currentWaypoint;
            currentWaypoint=waypoints.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
            
            if(prevWaypoint==currentWaypoint){
                complete=true;
            }
        }
    }
}
