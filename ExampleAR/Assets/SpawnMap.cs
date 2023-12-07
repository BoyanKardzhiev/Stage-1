using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnMap : MonoBehaviour
{
    [SerializeField]
    GameObject Indication;
    void Start()
    {
        gameObject.SetActive(false);
        Indication.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(SpawnableObject.firstItemSpawned)
        {
            Indication.SetActive(true);
            transform.position = SpawnableObject.spawnedPosition;
        }
    }
}
