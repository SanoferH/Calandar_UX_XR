using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarDayViewAdjuster : MonoBehaviour
{
    [SerializeField] private IndexPinchSelector _selector;
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private GameObject _amTime;
    [SerializeField] private GameObject _pmTime;

    public bool scrolled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    
    // Update is called once per frame
    void Update()
    {
        if (scrolled)
        {
            _scrollbar.value = 0.0f;
            _pmTime.SetActive(true);
            _amTime.SetActive(false);
        }
        else
        {
            _scrollbar.value = 1.0f;
            _pmTime.SetActive(false);
            _amTime.SetActive(true);
        }
      
    }

   
}
