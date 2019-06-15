using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

public class CarUserControl : MonoBehaviour
{
    private CarController m_Car;
    float h; //horizontal
    float v; //Vertical

    public int thisCarID;

    private void Awake()
    {
        m_Car = GetComponent<CarController>();
    }
    private void FixedUpdate()
    {
        if (RaceManager.instance.isRacing == true)
        {
            if(thisCarID == 1)
            {
                h = CrossPlatformInputManager.GetAxis("Horizontal_P1");
                v = CrossPlatformInputManager.GetAxis("Vertical_P1");
            }
            else if (thisCarID == 2)
            {
                h = CrossPlatformInputManager.GetAxis("Horizontal_P2");
                v = CrossPlatformInputManager.GetAxis("Vertical_P2");
            }
            else
            {
                h = CrossPlatformInputManager.GetAxis("Horizontal");
                v = CrossPlatformInputManager.GetAxis("Vertical");
            }
        }

        m_Car.Move(h, v, v, 0f);
    }
}

