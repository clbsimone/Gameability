using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    private float y;
    private float x;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(x, 0, y);

        transform.position += move*0.1f;
        transform.forward = move;
        
    }
}
