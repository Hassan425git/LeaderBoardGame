using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            //m_audioSource.PlayOneShot(Footstep_dirt.wav);
        }
    }
}
