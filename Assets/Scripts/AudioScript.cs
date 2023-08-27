using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource flashSFX;
    public AudioSource startSFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playFlashSFX()
    {
        flashSFX.Play();
    }

    public void playStartSFX()
    {
        startSFX.Play();
    }
}
