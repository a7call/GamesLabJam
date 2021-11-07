using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsBar : MonoBehaviour
{
    public List<Image> heartList;
    public Sprite brokenHeartSprite;
    
    private int _index = 0;
    
    public void LooseHeart()
    {
        if (_index >= heartList.Count)
        {
            return;
        }
        heartList[_index].sprite = brokenHeartSprite;
        _index++;
    }
    
}
