using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    [SerializeField]
    GameObject QuestSelectionCutscene;
    // Start is called before the first frame update
    void Start()
    {
        QuestSelectionCutscene.SetActive(true);   
    }
}
