using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 100f;

    private float currentSpeed = 0f;
    private float acceleration = 5f;
    private float deceleration = 10f;

    void Update()
    {
        // Get steering input (assuming steering wheel is axis 0)
        float steer = Input.GetAxis("Horizontal");

        // Get acceleration input (assuming throttle is axis 1, or use keyboard for simplicity)
        float accel = Input.GetAxis("Vertical"); // Or use specific axis for steering wheel

        // Simple acceleration/deceleration
        if (accel > 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, speed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
        }

        // Move forward
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // Turn
        transform.Rotate(Vector3.up, steer * turnSpeed * Time.deltaTime);

        // Send speed to Arduino (assuming speed 0-100)
        int displaySpeed = Mathf.RoundToInt(currentSpeed / speed * 100);
        if (SerialCommunicator.Instance != null)
        {
            SerialCommunicator.Instance.SendSpeed(displaySpeed);
        }
    }
}