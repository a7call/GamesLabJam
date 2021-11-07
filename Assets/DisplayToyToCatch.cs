using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayToyToCatch : MonoBehaviour
{
    public Sprite Bunny;
    public Sprite Bear;

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
                image.sprite = Bear;
                break;
            case ToyType.Bunny:
                image.sprite = Bunny;
                break;
        }
    }
}
