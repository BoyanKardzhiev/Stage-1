using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;



public class SpawnableObject : MonoBehaviour
{
    [SerializeField]
    GameObject Indication, Scenery;

    [SerializeField]
    GameObject KeyPrefab, FinalItemKeyScreen, WantedItems, EnterTheTavern, TavernDoor;
    Animator TavernDoorAnim;
    int itemsCollected;
    public static bool FinalKeyScreenSpawned;

    [SerializeField]
    ARRaycastManager m_RaycastManager;
    bool spawned;

    [SerializeField]
    ARPlaneManager m_PlaneManager;

    List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    public static Vector3 spawnedPosition;
    public static bool firstItemSpawned;

    [SerializeField]
    List<GameObject> Questions = new List<GameObject>();
    [SerializeField]
    List<GameObject> Answers = new List<GameObject>();

    [SerializeField]
    List<GameObject> PlacebleObjects = new List<GameObject>();

    [SerializeField]
    List<GameObject> FoundObjects = new List<GameObject>();

    [SerializeField]
    List<TextMeshProUGUI> FoundText1 = new List<TextMeshProUGUI>();

    [SerializeField]
    List<TextMeshProUGUI> FoundText2 = new List<TextMeshProUGUI>();

    Camera arCam;
    Transform arCamTransform;
    GameObject spawnedObject;
    GameObject spawnablePrefab;

    public int objectNumber;
    int foundNumber;
    int quest;
    Animator foundObjectAnim;
    // Start is called before the first frame update
    void Start()
    {
        Indication.SetActive(false);
        Scenery.SetActive(false);

        firstItemSpawned = false;
        spawnedObject = null;
        arCam = GameObject.Find("AR Camera").GetComponent<Camera>();
        arCamTransform = GameObject.Find("AR Camera").GetComponent<Transform>();

        //m_PlaneManager = GetComponent<ARPlaneManager>();
        m_PlaneManager.planesChanged += PlaneChanged;
        spawned = false;

        objectNumber = 0;
        itemsCollected = 0;
        FinalItemKeyScreen.SetActive(false);
        FinalKeyScreenSpawned = false;
        TavernDoorAnim = TavernDoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        QuestUpdate();
        HandleKeySpawn();

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
                    if(hit.collider.gameObject.tag == "Collectable")
                    {
                        foundNumber = hit.collider.gameObject.GetComponent<FoundObject>().obj.CollectableNumber;
                        FoundObjects[foundNumber].SetActive(true);
                        itemsCollected++;

                        if(foundNumber == 4)
                        {
                            TavernDoorAnim.SetTrigger("KeyCollected");
                        }

                        if (quest == 0)
                        {
                            foundObjectAnim = FoundText1[foundNumber].GetComponent<Animator>();
                            FoundText1[foundNumber].enabled = true;
                            foundObjectAnim.SetTrigger("FoundMove");
                        }
                        else
                        {
                            foundObjectAnim = FoundText2[foundNumber].GetComponent<Animator>();
                            FoundText2[foundNumber].enabled = true;
                            foundObjectAnim.SetTrigger("FoundMove");
                        }

                        Destroy(hit.collider.gameObject);
                    }    
                }
            }
        }

        /*RaycastHit hit;
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
                        itemsCollected++;

                        if(foundNumber == 4)
                        {
                            TavernDoorAnim.SetTrigger("KeyCollected");
                        }

                        if (quest == 0)
                        {
                            foundObjectAnim = FoundText1[foundNumber].GetComponent<Animator>();
                            FoundText1[foundNumber].enabled = true;
                            foundObjectAnim.SetTrigger("FoundMove");
                        }
                        else
                        {
                            foundObjectAnim = FoundText2[foundNumber].GetComponent<Animator>();
                            FoundText2[foundNumber].enabled = true;
                            foundObjectAnim.SetTrigger("FoundMove");
                        }

                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        SpawnPrefab(m_Hits[0].pose.position, m_Hits[0].pose.rotation);

                        if(!firstItemSpawned)
                        {
                            firstItemSpawned = true;
                            Scenery.transform.position = m_Hits[0].pose.position;
                            Scenery.transform.rotation = m_Hits[0].pose.rotation;
                            Scenery.SetActive(true);
                            //Indication.SetActive(true);
                        }
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
        }*/
    }

    private void SpawnPrefab(Vector3 spawnPosition, Quaternion rotation)
    {
        if (objectNumber == 9)
        {
            spawnedObject = Instantiate(spawnablePrefab, spawnPosition, rotation);
            spawnedObject.SetActive(false);
        }
        else spawnedObject = Instantiate(spawnablePrefab, spawnPosition, rotation);
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
            Questions[quest].SetActive(true);
            Answers[quest].SetActive(true);
        }
    }

    void HandleKeySpawn()
    {
        if (itemsCollected < 4)
        {
            KeyPrefab.SetActive(false);
        }
        else 
        {
            KeyPrefab.SetActive(true);
            if(!FinalKeyScreenSpawned)
            {
                WantedItems.SetActive(false);
                EnterTheTavern.SetActive(true);

                FinalItemKeyScreen.SetActive(true);
                FinalKeyScreenSpawned = true;
            }
        }
    }

    public void CollectItem()
    {
        itemsCollected++;
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if(args.added != null && !spawned)
        {
            ARPlane arPlane = args.added[0];
            //spawnedObject = Instantiate(PlacebleObjects[2], arPlane.transform.position, Quaternion.identity);

            Vector3 startPosition = new Vector3(arPlane.transform.position.x, arPlane.transform.position.y, arCamTransform.position.z);
            Scenery.transform.position = startPosition;
            Scenery.transform.Rotate(arPlane.transform.rotation.x, 0, arPlane.transform.rotation.z);
            //Scenery.SetActive(true);

            spawned = true;

            m_PlaneManager.enabled = false;
        }
    }
}
