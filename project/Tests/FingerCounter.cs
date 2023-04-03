using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Count the extended fingers
public class FingerCounter : MonoBehaviour { 
    private const int power = 2; // exponent for calculate the distance of the fingers
    private const double minimal_distance = 0.092; // minimal distance from the central point for indentify if a finger is extended (this number was chose empirically after some tests)
    private const double minimal_distance_thumb = 0.0958; // minimal distance for the thumbs because they have a different distance from the central point (this number was chose empirically after some tests)
    
    public GameObject hand_sx, hand_dx; // right and left hand's middle points
    public GameObject thumb_sx, thumb_dx; // right and left thumbs
    public GameObject index_sx, index_dx; // right and left indexes
    public GameObject middle_sx, middle_dx; // right and left middles
    public GameObject ring_sx, ring_dx; // right and left rings
    public GameObject pinky_sx, pinky_dx; // right and left pinkyies

    private double index_distance, middle_distance, thumb_distance, pinky_distance, ring_distance; // distance of every finger
    private double x_hand, y_hand, z_hand; // x, y, z hand coordinates
    private double x_index, x_middle, x_thumb, x_pinky, x_ring; // x coordinates of every finger
    private double y_index, y_middle, y_thumb, y_pinky, y_ring; // y coordinates of every finger
    private double z_index, z_middle, z_thumb, z_pinky, z_ring; // z coordinates of every finger
    private int fingersCounter; // number of extended fingers
    private int[] fingerUp = {0,0,0,0,0}; // array for see if a finger is exstended or not
    private int counter;// contains the number to return

    // inizialize and reset all the variables
    void Start(){
        reset();
    }

    // MAIN CICLE
    void Update() {

        // check if the right hand is on the screen
        if(hand_dx.activeSelf == true){ 

            // get the x,y,z coordinates of the right hand's middle point
            x_hand = hand_dx.transform.position.x; 
            y_hand = hand_dx.transform.position.y;
            z_hand = hand_dx.transform.position.z;

            // get the x,y,z coordinates of the right hand's thumb
            x_thumb = thumb_dx.transform.position.x;
            y_thumb = thumb_dx.transform.position.y;
            z_thumb = thumb_dx.transform.position.z;

            // get the x,y,z coordinates of the right hand's index
            x_index = index_dx.transform.position.x;
            y_index = index_dx.transform.position.y;
            z_index = index_dx.transform.position.z;

            // get the x,y,z coordinates of the right hand's middle
            x_middle = middle_dx.transform.position.x;
            y_middle = middle_dx.transform.position.y;
            z_middle = middle_dx.transform.position.z;
 
            // get the x,y,z coordinates of the right hand's ring
            x_ring = ring_dx.transform.position.x;
            y_ring = ring_dx.transform.position.y;
            z_ring = ring_dx.transform.position.z;

            // get the x,y,z coordinates of the right hand's pinky
            x_pinky = pinky_dx.transform.position.x;
            y_pinky = pinky_dx.transform.position.y;
            z_pinky = pinky_dx.transform.position.z;

            assign_distance();

            fingersCounter = extended_fingers_counter(thumb_distance,index_distance,middle_distance,ring_distance,pinky_distance);
            Debug.Log("Number of extended fingers dx = "+fingersCounter);

            /*
            Debug:

            Debug.Log("Thumb distance = "+thumb_distance);
            Debug.Log("Index distance = "+index_distance);
            Debug.Log("Middle distance = "+middle_distance);
            Debug.Log("Ring distance = "+ring_distance);
            Debug.Log("Pinky distance = "+pinky_distance);
            */

            // Debug.Log("Right: [X = " + x + " Y = " + y + " Z = "+ z+"]");
        }
        
        // if the right hand isn't on the screen it reset all the distance
        else{
            reset();
        }

        //check if the left hand is on the screen
        if (hand_sx.activeSelf == true){

            // get the x,y,z coordinates of the left hand's middle point
            x_hand = hand_sx.transform.position.x; 
            y_hand = hand_sx.transform.position.y;
            z_hand = hand_sx.transform.position.z;

            // get the x,y,z coordinates of the left hand's thumb
            x_thumb = thumb_sx.transform.position.x;
            y_thumb = thumb_sx.transform.position.y;
            z_thumb = thumb_sx.transform.position.z;

            // get the x,y,z coordinates of the left hand's index
            x_index = index_sx.transform.position.x;
            y_index = index_sx.transform.position.y;
            z_index = index_sx.transform.position.z;

            // get the x,y,z coordinates of the left hand's middle
            x_middle = middle_sx.transform.position.x;
            y_middle = middle_sx.transform.position.y;
            z_middle = middle_sx.transform.position.z;

            // get the x,y,z coordinates of the left hand's ring
            x_ring = ring_sx.transform.position.x;
            y_ring = ring_sx.transform.position.y;
            z_ring = ring_sx.transform.position.z;

            // get the x,y,z coordinates of the left hand's pinky
            x_pinky = pinky_sx.transform.position.x;
            y_pinky = pinky_sx.transform.position.y;
            z_pinky = pinky_sx.transform.position.z;

            assign_distance();

            fingersCounter = extended_fingers_counter(thumb_distance,index_distance,middle_distance,ring_distance,pinky_distance);
            Debug.Log("Number of extended fingers sx = "+fingersCounter);

            /*
            Debug.Log("Thumb distance = "+thumb_distance);
            Debug.Log("Index distance = "+index_distance);
            Debug.Log("Middle distance = "+middle_distance);
            Debug.Log("Ring distance = "+ring_distance);
            Debug.Log("Pinky distance = "+pinky_distance);
            */

            // Debug.Log("Left: [X = " + x + " Y = " + y + " Z = "+ z+"]");
        }
        
        // if the left hand isn't on the screen it reset all the distance
        else{
            reset();  
        }
        reset();
    }

    // calculate distance of every finger from the middle point of the hand
    double calculate_distance(double x, double y, double z, double x_finger, double y_finger, double z_finger){
        return Math.Sqrt((Math.Pow(x - x_finger, power) + Math.Pow(y - y_finger, power) + Math.Pow(z - z_finger,power))); // return double
    }

    // recognizes the number made with the hand and return the number of the fingers extended
    int extended_fingers_counter(double thumb_distance, double index_distance, double middle_distance, double ring_distance, double pinky_distance){

        counter = 0; // reset the counter

        // check if there are 0 or 5 fingers extended on the hand and assign 0 to counter
        if(thumb_distance >= minimal_distance_thumb && index_distance >= minimal_distance && middle_distance >= minimal_distance && ring_distance >= minimal_distance && pinky_distance >= minimal_distance){
            counter = 0;  
        }else if(thumb_distance < minimal_distance_thumb && index_distance < minimal_distance && middle_distance < minimal_distance && ring_distance < minimal_distance && pinky_distance < minimal_distance){
            counter = 0;
        }
        
        // if the finger is extended set to one the cell of the correspondent finger
        else{
            if(thumb_distance >= minimal_distance_thumb){
                    fingerUp[0] = 1;
            }else{
                    fingerUp[0] = 0;
            }
            if(index_distance >= minimal_distance){
                    fingerUp[1] = 1;
            }else{
                    fingerUp[1] = 0;
            }
            if(middle_distance >= minimal_distance){
                    fingerUp[2] = 1;
            }else{
                    fingerUp[2] = 0;
            }
            if(ring_distance >= minimal_distance){
                    fingerUp[3] = 1;
            }else{
                    fingerUp[3] = 0;
            }
            if(pinky_distance >= minimal_distance){
                    fingerUp[4] = 1;
            }else{
                    fingerUp[4] = 0;
            }
            
            // sum to counter the number of extended fingers
            for(int a = 0; a < 5; a++){
                counter += fingerUp[a];
            }
        }
        return counter; // return int
    }

    // reset all the distances, array and variables
    void reset(){ 
        thumb_distance = 0;
        index_distance = 0;
        middle_distance = 0;
        ring_distance = 0;
        pinky_distance = 0;
        for(int a = 0; a < 5; a++){
            fingerUp[a] = 0;
        }
        fingersCounter = 0;
        counter = 0;
    }

    // assign the distance of every finger
    void assign_distance(){
        thumb_distance = calculate_distance(x_hand,y_hand,z_hand,x_thumb,y_thumb,z_thumb);
        index_distance = calculate_distance(x_hand,y_hand,z_hand,x_index,y_index,z_index);
        middle_distance = calculate_distance(x_hand,y_hand,z_hand,x_middle,y_middle,z_middle);
        ring_distance = calculate_distance(x_hand,y_hand,z_hand,x_ring,y_ring,z_ring);
        pinky_distance = calculate_distance(x_hand,y_hand,z_hand,x_pinky,y_pinky,z_pinky);
    }
}