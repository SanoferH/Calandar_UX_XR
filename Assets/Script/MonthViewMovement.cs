using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonthViewMovement : MonoBehaviour
{
    private Vector3 _initialPostion;
    // Start is called before the first frame update
    void Start()
    {
      //Debug.Log("Rect Position : "+ GetComponent<RectTransform>().localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<RectTransform>().localPosition = new Vector3()
        GetComponent<RectTransform>().localPosition = new Vector3(GetComponent<RectTransform>().localPosition.x, 0, 0);
    }
}
