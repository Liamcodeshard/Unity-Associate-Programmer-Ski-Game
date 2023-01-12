using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{

    [SerializeField] private List<CinemachineVirtualCamera> gameCameras = new List<CinemachineVirtualCamera>();
    public static int camChoice = 0;


    private void OnEnable()
    {
        foreach (var cam in gameCameras)
        {
            MainCamSwitcher.Register(cam);

        }

        MainCamSwitcher.SwitchCamera(gameCameras[0]);

    }
    private void OnDisable()
    {
        foreach (var cam in gameCameras)
        {
            MainCamSwitcher.UnRegister(cam);

        }



    }
    void Update()
    {
        if (camChoice >= gameCameras.Count) camChoice = 0;
        MainCamSwitcher.SwitchCamera(gameCameras[camChoice]);
        

    }



}
