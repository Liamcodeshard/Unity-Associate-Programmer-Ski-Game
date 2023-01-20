using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShaker : MonoBehaviour
{
    public static CinemachineShaker Instance { get; private set; }
    private CinemachineVirtualCamera cinemachineVirtualCam;
    public float shakeTimer;

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachnBasicMultiChannelPerlin =
            cinemachineVirtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachnBasicMultiChannelPerlin.m_AmplitudeGain = intensity;

    }

    private void Update()
    {
        if(shakeTimer>0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                ShakeCamera(0, 0);
            }
        }
    }

}
