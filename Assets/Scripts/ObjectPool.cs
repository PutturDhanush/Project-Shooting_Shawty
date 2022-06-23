using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public List<GameObject> objects;
    public Vector3 objectRotation = new Vector3(0,0,0);
    public float throwForce = 20;
    public int poolNumber =4;
    public float timeGap = 0.5f;

    public float widthRange = 12.0f;
    public float closeDis = 8.0f;
    public float farDis = 12.0f;

    private GameObject[] poolArray;
    public GameObject[] spawnerArray = new GameObject[8];
    void Start()
    {
        Physics.gravity = new Vector3(0,-18,0);

        // creating array of objects to pool
        poolArray = new GameObject[objects.Count * poolNumber];

        for (int i=0; i<objects.Count; i++)
        {
            for (int j = poolNumber *i ;j <poolNumber *(i+1);j++)
            {
                poolArray[j] = Instantiate(objects[i]);
                poolArray[j].SetActive(false);
            }
        }
       
        InvokeRepeating("RandomObjectSpawn", 2.0f, timeGap);  // Starts continuous spawnning

    }

    // spawns random oject at random position
    void RandomObjectSpawn()
    {
        GameObject randomSpaw = RandomSpawner();
        Vector3 randomPos = randomSpaw.transform.position + new Vector3(0,6,0);

        GameObject randomObj = RandomObject();
        Rigidbody randomObjRb = randomObj.GetComponent<Rigidbody>();
        Object randomObjScript = randomObj.GetComponent<Object>();

        randomObj.transform.position = randomPos;
        randomObj.transform.eulerAngles = objectRotation;
        randomObjScript.currentHealth = randomObjScript.health;
        randomObj.SetActive(true);
        randomObjRb.velocity = new Vector3(0, 0, 0);
        randomObj.GetComponent<Rigidbody>().AddForce(Vector3.up * throwForce, ForceMode.Impulse);
        randomObjScript.sourceSpawner = randomSpaw;

    }


    // returns random inactive game object
    GameObject RandomObject()
    {
        GameObject randomObj = poolArray[Random.Range(0, poolArray.Length)];
        if (randomObj.activeInHierarchy == false)
        {
            return randomObj;
        }
        return RandomObject();

    }

    // returns random usable spawnner position given the ranges
    GameObject RandomSpawner()
    {
        GameObject temp = spawnerArray[Random.Range(0, spawnerArray.Length)];
        SpawnerBlocks tempScript = temp.GetComponent<SpawnerBlocks>();

        if (tempScript.canBeUsed)
        {
            tempScript.canBeUsed = false;
            return temp;
        }
        return RandomSpawner();
    }

    public void GameEnder()
    {
        CancelInvoke("RandomObjectSpawn");
    }
}
