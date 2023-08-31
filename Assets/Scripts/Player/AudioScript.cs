using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource flashSFX;
    public AudioSource startSFX;
    public AudioSource warningSFX;
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

    public void playWarningSFX()
    {
        warningSFX.Play();
    }

    //Stop playing all audio
    public void stopAllSFX()
    {
        flashSFX.Stop();
        startSFX.Stop();
        warningSFX.Stop();
    }
}
