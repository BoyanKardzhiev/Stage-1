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
        case 2:
                messages.text = "Keep going!";
                break;
        case 3:
        case 4:
                messages.text = "Almost there!";
                break;
        case 5:
                messages.text = "Final tavern reached!";
                break;

            default:
                messages.text = "Welcome!";
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
