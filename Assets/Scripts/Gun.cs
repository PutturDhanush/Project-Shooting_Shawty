using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float gunDamage = 2;
    [SerializeField] private float range = 100;
    private float fireRate = 2;
    private float nextFireTime =0;

    private GameObject fpsCam;
    private CameraMovement cameraScript;
    private AudioSource soundSource;
    public AudioClip fireSound;
    public ParticleSystem muzzleFlash;

    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        fpsCam = GameObject.Find("PlayerSystem");
        cameraScript = fpsCam.GetComponent<CameraMovement>();

    }

    void Update()
    {
        // shoots with given fire rate
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + (1 / fireRate);
        }
    }

    void Shoot()
    {
        RaycastHit ray;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out ray, range))
        {
            Object obj = ray.transform.GetComponent<Object>();   // if the object is destroyable (has Object script on it) only then the obj will be assigned
            if (obj != null)
            {
                obj.TakeDamage(gunDamage);
            }
        }
        soundSource.PlayOneShot(fireSound,GameManager.instance.soundEffects);
        cameraScript.GetRecoil();
        muzzleFlash.Play();
    }

}
