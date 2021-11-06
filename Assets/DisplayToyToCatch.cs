using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayToyToCatch : MonoBehaviour
{
    public Color BearColor;
    public Color BunnyColor;
    public Color OtherColor;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetDisplayToyToCatch(ToyType type)
    {
        
        switch (type)
        {
            case ToyType.Bear:
                image.color = BearColor;
                break;
            case ToyType.Bunny:
                image.color = BunnyColor;
                break;
            case ToyType.Other:
                image.color = OtherColor;
                break;
        }
    }
}
