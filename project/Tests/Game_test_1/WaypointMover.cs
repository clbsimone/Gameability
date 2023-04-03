using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class that makes the car move following the waypoints
public class WaypointMover : MonoBehaviour
{
    //attribute that become true if the car arrives to the last waypoint
    public bool complete=false;
    //attribute used to set the order of the cars (1->first car, 4->last car)
    [SerializeField] public int indexCar;
    //attribute that is an object containing a series of waypoints
    [SerializeField] private Waypoints waypoints;

    //attribute to set the movement speed
    [SerializeField] private float moveSpeed = 5f;
    //attribute containing the distance between the car and the waypoint to change waypoint
    [SerializeField] private float distanceTreshold=0.1f;
    //attribute that contain the waypoint the car is arrived to 
    private Transform currentWaypoint;
    //attribute that contai the previous waypoint where the car was
    private Transform prevWaypoint;
    
    void Start()
    {
        //set the position to the first waypoint
        currentWaypoint=waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //the car looks at the next waypoint
        currentWaypoint=waypoints.GetNextWaypoint(currentWaypoint);
        
    }

    void Update()
    {
        
    }

    //function that makes the car move following the waypoints
    public void MoveCar()
    {
        //MoveTowards makes the car move point to point using the car position and the waypoint position
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        //condition to change the waypoint the car is looking at, if the distance between the car and the current waypoint is less than 0,1 i get a new waypoint
        if(Vector3.Distance(transform.position, currentWaypoint.position) < distanceTreshold)
        {
            //updates the previous waypoint and the current waypoint 
            prevWaypoint = currentWaypoint;
            currentWaypoint=waypoints.GetNextWaypoint(currentWaypoint);
            transform.LookAt(currentWaypoint);
            
            //if the car arrives to the last waypoint the attribute complete is set true
            if(prevWaypoint==currentWaypoint){
                complete=true;
            }
        }
    }
}
