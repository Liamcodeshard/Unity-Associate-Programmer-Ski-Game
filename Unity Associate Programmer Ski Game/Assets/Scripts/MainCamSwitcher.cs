﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using Cinemachine;

public static class MainCamSwitcher
{
    static List<CinemachineVirtualCamera> _cameras = new List<CinemachineVirtualCamera>();
    public static CinemachineVirtualCamera ActiveCamera = null;

    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == ActiveCamera;
       
    }
    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        ActiveCamera = camera;
        foreach (CinemachineVirtualCamera c in _cameras)
        {
            if (c != camera)
            {
                c.Priority = 0;
            }
        }
        //Debug.Log(ActiveCamera + " isActive");

    }
    public static void Register(CinemachineVirtualCamera camera)
    {
        _cameras.Add(camera);
        //Debug.Log(camera + "Registered");
    }

    public static void UnRegister(CinemachineVirtualCamera camera)
    {
        _cameras.Remove(camera);
        //Debug.Log(camera + "UnRegistered");
    }

}
