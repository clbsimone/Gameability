using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0f, 2f)]
    [SerializeField] private float WaypointsSize=1f;
    void OnDrawGizmos()
    {
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, WaypointsSize);
        }
        Gizmos.color = Color.red;
        for(int i=0; i<transform.childCount -1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+1).position);
        }
    }

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
