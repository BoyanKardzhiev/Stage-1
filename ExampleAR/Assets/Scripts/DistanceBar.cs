using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceBar : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI messages;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    int distancePassed;

    void Start()
    {
        slider.value = 0;
        distancePassed = 0;
    }

    void Update()
    {
        switch(distancePassed)
        {
        case 1:
                messages.text = "4 meters left!";
                break;
            case 2:
                messages.text = "3 meters left!";
                break;
        case 3:
                messages.text = "2 meters left!";
                break;
            case 4:
                messages.text = "1 meters left!";
                break;
            case 5:
                messages.text = "Final tavern reached!";
                break;

            default:
                messages.text = "5 meters left!";
                break;
        }
    }
    public void SetDistance(int distance)
    {
        distancePassed = distancePassed + distance;
        slider.value = distancePassed;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
