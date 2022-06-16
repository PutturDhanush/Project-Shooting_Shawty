using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float gunDamage = 1;
    public Camera fpsCam;
    [SerializeField] private float range = 50;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        RaycastHit ray;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward,out ray,range))
        {
            Debug.Log(ray.transform.gameObject.name);
        }

        bool rayHasHit = (ray.transform != null);

        if (rayHasHit)
        {
            Object obj = ray.transform.GetComponent<Object>();   // if the object is destroyable only then the obj will be assigned
            if (obj != null)    
            {
                obj.takeDamage(gunDamage);
            }
        }

    }

}
