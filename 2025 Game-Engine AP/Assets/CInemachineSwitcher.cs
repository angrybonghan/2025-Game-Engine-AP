using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 public class CInemachineSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCam;
    public CinemachineFreeLook freeLookCam;
    public bool usingFreeLook = false;

    // Start is called before the first frame update
    void Start()
    {
        VirtualCam.Priority = 10;
        freeLookCam.Priority = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown(1))
        {
            usingFreeLook = !usingFreeLook;
            if (usingFreeLook)
            {
                freeLookCam.Priority = 20;
                VirtualCam.Priority = 0;
            }
            else
            {
                freeLookCam.Priority = 0;
                VirtualCam.Priority = 20;

            }

        }



    }
}
