using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to manage the precedence of the intersection
public class MoveIntersection : MonoBehaviour
{
    //attributes whith the cars to move
    [SerializeField] WaypointMover carRed;
    [SerializeField] WaypointMover carYellow;
    [SerializeField] WaypointMover carWite;
    [SerializeField] WaypointMover carSlash;

    //counter set at 1 because the first car hai index 1
    private int i=1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Precedence();
    }

    //function that moves the cars according to the precedences
    private void Precedence()
    {   
        //conditions to verify which car has to move
        if(carRed.indexCar == i){
            carRed.MoveCar();
            //if the car arrives at the last waypoint the counter is increased by 1
            if(carRed.complete){
                i++;
            }
        }

        if(carYellow.indexCar == i){
            carYellow.MoveCar();
            //if the car arrives at the last waypoint the counter is increased by 1
            if(carYellow.complete){
                i++;
            }
        }

        if(carWite.indexCar == i){
            carWite.MoveCar();
            //if the car arrives at the last waypoint the counter is increased by 1
            if(carWite.complete){
                i++;
            }
        }
        
        if(carSlash.indexCar == i){
            carSlash.MoveCar();
            //if the car arrives at the last waypoint the counter is increased by 1
            if(carSlash.complete){
                i++;
            }
        }
    }
}
