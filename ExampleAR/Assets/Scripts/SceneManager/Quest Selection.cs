using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestSelection : MonoBehaviour
{
    public static int questNumber;
    public static bool questSelected;

    [SerializeField]
    GameObject IntroCutscene, Quest1Cutscene, Quest2Cutscene;

    void Start()
    {
        IntroCutscene.SetActive(false);
        questNumber = 0;
        questSelected = false;
    }

    public void LoadQuest1()
    {
        questSelected = true;
        questNumber = 0;
        Quest1Cutscene.SetActive(true);
    }

    public void LoadQuest2()
    {
        questSelected = true;
        questNumber = 1;
        Quest2Cutscene.SetActive(true);
    }
}
