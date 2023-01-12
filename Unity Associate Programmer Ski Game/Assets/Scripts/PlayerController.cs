 using System.Collections;
using System.Collections.Generic;
 using System.Runtime.CompilerServices;
 using Cinemachine;
 using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speeed = 60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speeed * Time.deltaTime);
    }
}
