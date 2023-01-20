using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform camTrans;

    public float shakeTime;
    public float shakeRange;

    private Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        camTrans = Camera.main.transform;
        originalPosition  = camTrans.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ShakeCamera());


    }
    
    IEnumerator ShakeCamera()
    {
        float elapsedTime = 0;

        while (elapsedTime < shakeTime)
        {
            // we store the shake in a temp. variable
            Vector3 pos = originalPosition + Random.insideUnitSphere * shakeRange;
            
            // z axis gets restored
            pos.z = originalPosition.z;

            //new positions are transferred to Camera
            //camTrans.position = pos;
            camTrans.position = Vector3.Lerp(originalPosition, pos, shakeRange);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset to original position or the camera will finish in a different location
        camTrans.position = originalPosition;
    }
}
