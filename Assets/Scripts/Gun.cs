using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float gunDamage = 3;
    [SerializeField] private float range = 50;
    private float fireRate = 3;
    private float nextFireTime =0;

    public Camera fpsCam;
    void Start()
    {
        
    }

    void Update()
    {
        // shoots with given fire rate
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            shoot();
            nextFireTime = Time.time + (1 / fireRate);
        }
    }

    void shoot()
    {
        RaycastHit ray;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward,out ray,range))
        {
            Object obj = ray.transform.GetComponent<Object>();   // if the object is destroyable (has Object script on it) only then the obj will be assigned
            if (obj != null)
            {
                obj.takeDamage(gunDamage);
            }
        }

    }

}
