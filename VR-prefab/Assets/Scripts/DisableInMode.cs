﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInMode : MonoBehaviour
{
    /*
     * Disables VR objects in non VR
     * Disables non VR objects in VR
    */

    public bool VrObject;

    void Start ()
    {
        //VR - DISABLE
        if(UnityEngine.XR.XRSettings.enabled && !VrObject)
        {
            gameObject.SetActive(false);
        }

        //Non VR - DISABLE
        else if (!UnityEngine.XR.XRSettings.enabled && VrObject)
        {
            gameObject.SetActive(false);
        }
    }
}
