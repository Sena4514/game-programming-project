using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public Vector3 axis = Vector3.up;
    public Movement movement;
    public float _movementSpeed = 5f;
    public void SetSpeed(float movementSpeed)
    {
        _movementSpeed = movementSpeed; 
    } 
    // Update is called once per frame
    void Update()
    {
        if (movement.walking == true)
        {
            transform.Rotate(Time.deltaTime * _movementSpeed * axis);
        }
       
    }
}
