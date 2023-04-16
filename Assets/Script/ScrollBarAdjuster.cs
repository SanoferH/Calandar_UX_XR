using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarAdjuster : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;

    [SerializeField] private IndexPinchSelector _selector;

    [SerializeField] private TextMeshProUGUI _text;
    
    [SerializeField] private TextMeshProUGUI _month;

    

    private int monthValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IncreaseMonthValue()
    {
        if (monthValue < 4)
        {
            monthValue += 1;
        }
       
    }
    
    public void DecreaseMonthValue()
    {
        if (monthValue > 0)
        {
            monthValue -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = _scrollbar.value.ToString();
      //  _scrollbar.value = 0.5f;
       // Debug.Log("Scroll Value: " + _scrollbar.value);
       if (_selector.canStartAdjustingScrollBar)
       {
           if ((_scrollbar.value > 0.0f && _scrollbar.value <= 0.25f)|| monthValue == 1)
           {
               _scrollbar.value = 0.0f;
               _month.text = "September";
           }
           if ((_scrollbar.value > 0.25f && _scrollbar.value <= 0.50f)|| monthValue == 2)
           {
               _scrollbar.value = 0.33f;
               _month.text = "October";
           }
           if ((_scrollbar.value > 0.50f && _scrollbar.value <= 0.75f)|| monthValue == 3)
           {
               _scrollbar.value = 0.66f;
               _month.text = "November";
           }
           if ((_scrollbar.value > 0.75f && _scrollbar.value <= 1.2f)|| monthValue == 4)
           {
               _scrollbar.value = 1.0f;
               _month.text = "December";
           }
       }
        
    }
}
