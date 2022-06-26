using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float health = 2;
    public float currentHealth = 2;
    public int points;

    public GameObject sourceSpawner;
    public GameObject blast;
    public AudioSource objectAudioSource;
    public AudioClip blastSound;
    private GameUIManager UIScript;

    private void Start()
    {
        UIScript = GameObject.Find("Start Canvas").GetComponent<GameUIManager>();
        objectAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (currentHealth <=0)                     // deactivates object is health is over
        {
            sourceSpawner.GetComponent<SpawnerBlocks>().canBeUsed = true;   // setting the spawner as usable after this object gets deactivated 
            UIScript.UpdateScore(points);
            Instantiate(blast, transform.position, transform.rotation);
            objectAudioSource.PlayOneShot(blastSound, GameManager.instance.soundEffects);
            gameObject.SetActive(false);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Spawner"))
        {
            UIScript.ObjectMissed();
            gameObject.SetActive(false);
        }
    }


    //will be called from gun script to do damage to the object
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
    
}
