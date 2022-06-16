using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float health = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <0)
        {
            gameObject.SetActive(false);
        }
    }

    public void takeDamage (float damage)
    {
        health -= damage;
    }
}
