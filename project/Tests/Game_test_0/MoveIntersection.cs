using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIntersection : MonoBehaviour
{
    [SerializeField] WaypointMover carRed;
    [SerializeField] WaypointMover carYellow;
    [SerializeField] WaypointMover carWite;
    [SerializeField] WaypointMover carSlash;

    private int i=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(carRed.indexCar == i){
            carRed.MoveCar();
            if(carRed.complete){
                i++;
            }
        }
        if(carYellow.indexCar == i){
            carYellow.MoveCar();
            if(carYellow.complete){
                i++;
            }
        }
        if(carWite.indexCar == i){
            carWite.MoveCar();
            if(carWite.complete){
                i++;
            }
        }
        if(carSlash.indexCar == i){
            carSlash.MoveCar();
            if(carSlash.complete){
                i++;
            }
        }
    }
}
