using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanoramicTriggerCamShifter : MonoBehaviour
{
    private void OnTriggerExit()
    {
        CameraSwitcher.camChoice++;
    }
}
