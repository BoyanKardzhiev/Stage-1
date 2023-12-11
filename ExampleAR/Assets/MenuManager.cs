using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject FinalKey, WantedItems, DistanceBar, Buttons, HideMenu, Scenery, StartScreen;

    [SerializeField]
    GameObject HideButton;

    [SerializeField]
    GameObject ShowButton;

    [SerializeField]
    GameObject Dropdown;

    [SerializeField]
    GameObject DropdownEnterTheTavern;

    [SerializeField]
    GameObject Intro;
    public static bool started;
    public static bool playing;

    bool isHiddenButton;
    bool isHiddenDropdown;
    // Start is called before the first frame update
    void Start()
    {
        StartScreen.SetActive(true);

        FinalKey.SetActive(false);
        WantedItems.SetActive(false);
        DistanceBar.SetActive(false);
        Buttons.SetActive(false);
        HideMenu.SetActive(false);
        Scenery.SetActive(false);

        isHiddenButton = false;
        isHiddenDropdown = false;

        started = true;
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        //HideButton.SetActive(!isHiddenButton);
        //ShowButton.SetActive(isHiddenButton);
        Dropdown.SetActive(!isHiddenDropdown);
        DropdownEnterTheTavern.SetActive(!isHiddenDropdown);
    }

    public void ChangeVisualButtons()
    {
        isHiddenButton = !isHiddenButton;
    }

    public void ChangeVisualDropdown()
    {
        isHiddenDropdown = !isHiddenDropdown;
    }

    public void ChangeBool()
    {
        started = true;
        playing = true;
    }

    public void StartIntro()
    {
        Intro.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
