using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField] Health health;
    Slider slider;


    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        SetHealth(health.health);
    }

    void SetHealth(int health)
    {
        slider.value = health;
    }
}
