using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushHitbox : MonoBehaviour
{
    [SerializeField] private Canvas deathCanvas;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("CRUSHAUDQWHD!");
            //if (other.gameObject.tag != "Player")
            //deathCanvas.GetComponent<DeathScreen>().Death("CRUSHED!");
    }
}
