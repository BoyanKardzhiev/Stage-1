using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnMap : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    [SerializeField]
    List<GameObject> MapObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<MapObjects.Count; i++)
        {
            MapObjects[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<MapObjects.Count; i++)
        {
            var ray = new Vector2(MapObjects[i].transform.position.x, MapObjects[i].transform.position.y); 

            if(m_RaycastManager.Raycast(ray, m_Hits, TrackableType.Planes))
            {
                Pose hitPose = m_Hits[i].pose;

                MapObjects[i].transform.position = hitPose.position;
                MapObjects[i].transform.rotation = hitPose.rotation;

                if(!MapObjects[i].activeInHierarchy)
                {
                    MapObjects[i].SetActive(true);
                }
            }
        }
        /*if(Input.touchCount != 0)
        {
            for(int i=0; i<MapObjects.Count; i++)
            {
                position = new Vector3(MapObjects[i].transform.position.x, m_Hits[0].pose.position.y, MapObjects[i].transform.position.z); 
                Instantiate(MapObjects[i], position, Quaternion.identity);
                MapObjects[i].SetActive(true);
            }
        }*/
    }
}
