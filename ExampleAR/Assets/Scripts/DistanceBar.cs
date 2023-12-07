using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceBar : MonoBehaviour
{
    public Slider slider;
    int distancePassed;

    void Start()
    {
        slider.value = 0;
        distancePassed = 0;
    }
    // Start is called before the first frame update
    public void SetDistance(int distance)
    {
        distancePassed = distancePassed + distance;
        slider.value = distancePassed;
    }
}