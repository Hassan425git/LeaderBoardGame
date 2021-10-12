using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footstep : MonoBehaviour
{
    public AudioSource sou;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Step()
    {
        sou.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
