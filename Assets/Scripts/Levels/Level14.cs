using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level14 : MonoBehaviour
{
    // Start is called before the first frame update
    private List<ModuleScript> modules = new List<ModuleScript>();
    private float cooldown = 2f;
    private float lastActive = 0f;
    void Start()
    {
        Debug.Log("Level 14: Its Getting Intense!");
        foreach (Transform moduleType in transform)
        {
            foreach (Transform module in moduleType.transform)
            {
                if (Random.Range(0, 5) < 3)
                    module.GetComponent<ModuleScript>().health = 4;
                else if (Random.Range(0, 2) < 1)
                    module.GetComponent<ModuleScript>().health = 2;
                else
                    module.GetComponent<ModuleScript>().health = 1;
                module.GetComponent<ModuleScript>().UpdateMaterial();
                modules.Add(module.GetComponent<ModuleScript>());
            }
        }
        GetComponent<Levels>().getWalls().transform.GetChild(Random.Range(0, 8)).gameObject.SetActive(true);
        GetComponent<Levels>().getWalls().transform.GetChild(Random.Range(0, 8)).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (modules.TrueForAll(module => module.isLit))
        {
            foreach (var module in modules)
            {
                module.LightDown();
            }
            for (int i = 0; i < GetComponent<Levels>().getWalls().transform.childCount; i++)
            {
                GetComponent<Levels>().getWalls().transform.GetChild(i).gameObject.SetActive(false);
            }
            GetComponent<Levels>().LoadNextLevel();
        }
    }

    void Update()
    {
        if (Time.time > lastActive + cooldown)
        {
            Debug.Log("Fire!");
            lastActive = Time.time;
            Vector3 pos = GetComponent<Levels>().getCrushers().transform.GetChild(Random.Range(0, 2)).GetChild(Random.Range(0, 9)).transform.position;
            GetComponent<Levels>().WarningSign(pos.x, pos.z);
            GetComponent<Levels>().getCrushers().transform.GetChild(Random.Range(0, 2)).GetChild(Random.Range(0, 9)).gameObject.GetComponent<Crusher>().Crush(0.1f);
            StartCoroutine(FireShow(pos.x, pos.z, 1.4f));
        }
    }

    private IEnumerator FireShow(float x, float z, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject fire = Instantiate(GetComponent<Levels>().getFire(), new Vector3(x, 0.01f, z), Quaternion.identity);
        yield return new WaitForSeconds(10f);
        Destroy(fire);
    }
}