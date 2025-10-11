using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Transform fill;
    public Slider slider;
    private Image image;


    public void SetMaxTime(float time)
    {
        slider.maxValue = time;
        slider.value = time;
    }

    public void setTime(float time)
    {
        slider.value = time;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        image = fill.GetComponentInChildren<Image>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (slider.value <= slider.maxValue/2)
        {
           
            image.color = Color.yellow;

            if(slider.value <= slider.maxValue / 4)
            {
                image.color = Color.red;
            }

        }
        else
        {
            image.color = Color.green;
        }
    }
}
