using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject TurrentOn;
    public GameObject DustParticle;

    public void BulidPrefabs(GameObject TurrentPrefabs)
    {
        TurrentOn = Instantiate(TurrentPrefabs, transform.position, Quaternion.identity);
        Instantiate(DustParticle, transform.position, Quaternion.identity);
    }
}
