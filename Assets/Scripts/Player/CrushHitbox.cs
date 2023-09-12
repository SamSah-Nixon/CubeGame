using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushHitbox : MonoBehaviour
{
    [SerializeField] private Levels levels;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            levels.Death("CRUSHED!");
        }
              
    }
}
