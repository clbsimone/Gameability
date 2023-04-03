using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class that allows me to create a path using waypoints
public class Waypoints : MonoBehaviour
{
    //attributes used to increase the scale and the size of the waypoint to see it clearly 
    [Range(0f, 2f)]
    [SerializeField] private float WaypointsSize=1f;

    //function used to draw the waypoints in unity
    void OnDrawGizmos()
    {
        //draws a sphere for each of the child objects 
        foreach (Transform t in transform)
        {
            Gizmos.DrawWireSphere(t.position, WaypointsSize);
        }
        //sets the color of the waypoints to red
        Gizmos.color = Color.red;

        //draws a line to connect the waypoints
        for(int i=0; i<transform.childCount -1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+1).position);
        }
    }

    //function that returns the next waypoint
    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        if(currentWaypoint==null)
        {
            return transform.GetChild(0);
        }
        
        if(currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }
        
        else
        {
            return currentWaypoint;
        }
    }
}
