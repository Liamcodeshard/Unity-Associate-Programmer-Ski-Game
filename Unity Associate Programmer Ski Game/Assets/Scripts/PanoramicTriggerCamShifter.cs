using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PanoramicTriggerCamShifter : MonoBehaviour
{
    public CinemachineVirtualCamera thisCam;

    void Start()
    {

    }
    private void OnTriggerExit()
    {
        CameraSwitcher.camChoice++;
       /* Debug.Log(MainCamSwitcher.ActiveCamera);

        Debug.Log(thisCam);

        MainCamSwitcher.SwitchCamera(thisCam);

        Debug.Log(MainCamSwitcher.ActiveCamera);*/
    }
}
