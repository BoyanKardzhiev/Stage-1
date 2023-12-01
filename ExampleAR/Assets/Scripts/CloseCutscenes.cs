using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCutscenes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject closeCutscene, closeStartScreen;
    void Start()
    {
        MenuManager.started = false;
        closeCutscene.SetActive(false);
        closeStartScreen.SetActive(false);
    }
}
