using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float health = 2;
 
    void Update()
    {
        if (health <=0)                     // deactivates object is health is over
        {
            gameObject.SetActive(false);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Spawner"))
        {
            gameObject.SetActive(false);
        }
    }


    //will be called from gun script to do damage to the object
    public void takeDamage(float damage)
    {
        health -= damage;
    }
    
}
