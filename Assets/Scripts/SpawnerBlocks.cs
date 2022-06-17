using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBlocks : MonoBehaviour
{
    public bool canBeUsed;

    private void Start()
    {
        canBeUsed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        canBeUsed = true;
    }

}
