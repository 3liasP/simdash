using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float reverseSpeed = 5f;
    public float turnSpeed = 100f;

    private float currentSpeed = 0f;
    private float acceleration = 5f;
    private float deceleration = 10f;

    void Update()
    {
        // Get steering input (Axis 0 - steering wheel)
        float steer = Input.GetAxis("Horizontal");

        // Get acceleration/brake input (Axis 3 - pedals)
        // Axis 3 typically ranges from -1 (released) to 1 (pressed)
        float accelInput = Input.GetAxis("Vertical");

        // Calculate target speed based on input
        float targetSpeed = 0f;
        if (accelInput > 0.1f)
        {
            // Accelerate forward
            targetSpeed = speed * accelInput;
        }
        else if (accelInput < -0.1f)
        {
            // Reverse (if axis goes negative, or use separate brake axis)
            targetSpeed = reverseSpeed * accelInput;
        }

        // Smoothly move towards target speed
        if (targetSpeed != 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
        }

        // Move forward/backward
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // Turn (reduce turn speed when moving slowly or in reverse)
        float turnMultiplier = Mathf.Abs(currentSpeed) / speed;
        transform.Rotate(Vector3.up, steer * turnSpeed * turnMultiplier * Time.deltaTime);

        // Send speed to Arduino (assuming speed 0-100)
        int displaySpeed = Mathf.RoundToInt(Mathf.Abs(currentSpeed) / speed * 100);
        if (SerialCommunicator.Instance != null)
        {
            SerialCommunicator.Instance.SendSpeed(displaySpeed);
        }
    }
}