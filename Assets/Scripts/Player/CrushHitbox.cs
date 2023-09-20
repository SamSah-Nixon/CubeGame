using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushHitbox : MonoBehaviour
{
    [SerializeField] private Levels levels;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && levels.getCurrentLevel() != 5)
        {
            levels.Death("CRUSHED!");
        }
              
    }
}
