using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCutscenes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject closeCutscene, closeStartScreen, Tutorial;
    void Start()
    {
        //MenuManager.started = false;
        closeStartScreen.SetActive(false);
        Tutorial.SetActive(true);
        closeCutscene.SetActive(false);

    }

    void Update()
    {
        if(Input.touchCount > 0 && MenuManager.started)
        {
            MenuManager.started = false;
            Tutorial.SetActive(false);
        }
    }
}
