using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialCommunicator : MonoBehaviour
{
    public static SerialCommunicator Instance;

    SerialPort serialPort;
    public string portName = "COM3"; // Change to your Arduino port
    public int baudRate = 9600;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        serialPort = new SerialPort(portName, baudRate);
        try
        {
            serialPort.Open();
            Debug.Log("Serial port opened");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open serial port: " + e.Message);
        }
    }

    public void SendSpeed(int speed)
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.WriteLine(speed.ToString());
        }
    }

    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}