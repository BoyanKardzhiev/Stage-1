using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCutscenes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject closeCutscene, closeStartScreen, FinalItemKeyScreen, QuestSelection;

    [SerializeField]
    GameObject Tutorial, Answer, WantedItems, DistanceBar, Scenery;
    void Start()
    {
        Answer.SetActive(true);
        Tutorial.SetActive(true);
        WantedItems.SetActive(true);
        DistanceBar.SetActive(true);
        Scenery.SetActive(true);

        closeStartScreen.SetActive(false);
        closeCutscene.SetActive(false);
        QuestSelection.SetActive(false);
    }

    void Update()
    {
        if(Input.touchCount > 0 && MenuManager.started)
        {
            MenuManager.started = false;
            Tutorial.SetActive(false);
        }

        if(Input.GetTouch(0).phase == TouchPhase.Began && SpawnableObject.FinalKeyScreenSpawned)
        {
            FinalItemKeyScreen.SetActive(false);
        }
    }
}
