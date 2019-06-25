using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;
using Photon;

public class CarUserControl : Photon.PunBehaviour
{
    private PhotonView myPhotonView;
    private CarController m_Car;
    float h; //horizontal
    float v; //Vertical

    private void Awake()
    {
        this.myPhotonView = GetComponent<PhotonView>();
        m_Car = GetComponent<CarController>();

        if (myPhotonView.isMine)
        {
            //Cameraをアタッチする
            GameObject cam = PhotonNetwork.Instantiate("CameraPrefab", transform.position, transform.rotation, 0);
            /*
            transform.position = new Vector3(0, 3, -5);
            transform.rotation = Quaternion.Euler(20, 0, 0); //Carの向きが逆になってになってしまう問題を解決
            
            cam.transform.parent = this.transform;
            */
            //うまい位置アタッチにつかない…

        }
    }
    private void FixedUpdate()
    {
        if (myPhotonView.isMine)
        {
            if (RaceManager.instance.isRacing == true)
            {
                h = CrossPlatformInputManager.GetAxis("Horizontal");
                v = CrossPlatformInputManager.GetAxis("Vertical");
            }
            
            m_Car.Move(h, v, v, 0f);
        }
    }
}