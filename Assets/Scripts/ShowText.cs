using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowText : MonoBehaviour
{

    public GameObject car;
    private CarController car_script;
    private int carSpeed;

    public string textValue = "";
    public TMP_Text textElement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        car_script = car.GetComponent<CarController>();
        textValue = "Warning! Slow down!";
    }

    // Update is called once per frame
    void Update()
    {
        carSpeed = car_script.displaySpeed;
        if(carSpeed > 50)
        {
            textElement.text =  textValue;
        }
        else
        {
            textElement.text = "";
        }
    }
}
