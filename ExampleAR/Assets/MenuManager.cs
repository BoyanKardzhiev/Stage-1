using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject HideButton;

    [SerializeField]
    GameObject ShowButton;

    [SerializeField]
    GameObject Dropdown;

    bool isHiddenButton;
    bool isHiddenDropdown;
    // Start is called before the first frame update
    void Start()
    {
        isHiddenButton = false;
        isHiddenDropdown = false;
    }

    // Update is called once per frame
    void Update()
    {
        HideButton.SetActive(!isHiddenButton);
        //ShowButton.SetActive(isHiddenButton);
        Dropdown.SetActive(!isHiddenDropdown);
    }

    public void ChangeVisualButtons()
    {
        isHiddenButton = !isHiddenButton;
    }

    public void ChangeVisualDropdown()
    {
        isHiddenDropdown = !isHiddenDropdown;
    }
}
