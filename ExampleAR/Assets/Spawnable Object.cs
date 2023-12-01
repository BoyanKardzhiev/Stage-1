using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;



public class SpawnableObject : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager m_RaycastManager;
    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();

    [SerializeField]
    List<GameObject> Quests = new List<GameObject>();

    [SerializeField]
    List<GameObject> PlacebleObjects = new List<GameObject>();

    [SerializeField]
    List<GameObject> FoundObjects = new List<GameObject>();

    [SerializeField]
    List<TextMeshProUGUI> FoundText1 = new List<TextMeshProUGUI>();

    [SerializeField]
    List<TextMeshProUGUI> FoundText2 = new List<TextMeshProUGUI>();

    Camera arCam;
    GameObject spawnedObject;
    GameObject spawnablePrefab;

    public int objectNumber;
    int foundNumber;
    int quest;
    // Start is called before the first frame update
    void Start()
    {
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();

        objectNumber = 0;

    }

    // Update is called once per frame
    void Update()
    {
        QuestUpdate();

        spawnablePrefab = PlacebleObjects[objectNumber];

        if (Input.touchCount == 0 || MenuManager.started)
            return;

        RaycastHit hit;
        Ray ray = arCam.ScreenPointToRay(Input.GetTouch(0).position);

        if (m_RaycastManager.Raycast(Input.GetTouch(0).position,m_Hits))
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began && spawnedObject == null)
            {
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.gameObject.tag == "Spawnable" && !MenuManager.playing)
                    {
                        spawnedObject = hit.collider.gameObject;
                    }
                    else if(hit.collider.gameObject.tag == "Collectable")
                    {
                        foundNumber = hit.collider.gameObject.GetComponent<FoundObject>().obj.CollectableNumber;
                        FoundObjects[foundNumber].SetActive(true);

                        if(quest == 0) FoundText1[foundNumber].enabled = true;
                        else FoundText2[foundNumber].enabled = true;

                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        SpawnPrefab(m_Hits[0].pose.position, m_Hits[0].pose.rotation);
                    }    
                }
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Moved && spawnedObject != null)
            {
                spawnedObject.transform.position = m_Hits[0].pose.position;
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                spawnedObject = null;
            }
        }
    }

    private void SpawnPrefab(Vector3 spawnPosition, Quaternion rotation)
    {
        spawnedObject = Instantiate(spawnablePrefab, spawnPosition, rotation);
    }

    public void ChangeObjectNumber(int change)
    {
        objectNumber = change;
    }

    void QuestUpdate()
    {
        if(QuestSelection.questSelected)
        {
            quest = QuestSelection.questNumber;
            Quests[quest].SetActive(true);
        }
    }
}
