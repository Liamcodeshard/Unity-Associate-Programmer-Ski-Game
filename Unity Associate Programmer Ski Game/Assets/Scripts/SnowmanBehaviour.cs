using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanBehaviour : MonoBehaviour
{
    public ParticleSystem particalurPartical;
    public GameObject snowMan;


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            particalurPartical.gameObject.SetActive(true);
            Destroy(snowMan);

        }


    }
}
