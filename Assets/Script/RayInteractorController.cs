using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.HandPosing;
using UnityEngine;
using UnityEngine.UI;

public class RayInteractorController : MonoBehaviour
{

    [SerializeField] private GameObject LeftHandRay;
    [SerializeField] private GameObject RightHandRay;

    [SerializeField] private GameObject Controller;

     public Button _dayButton;
     public Button _weekButton;
    public Button _monthButton;
    [SerializeField] private GameObject _dayView;
    [SerializeField] private GameObject _weekView;
    [SerializeField] private GameObject _monthView;

    public bool isMonthActive;
    public bool isWeekActive;
    public bool isDayActive;
    // Start is called before the first frame update
    void Start()
    {
        Controller.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Component Name: "+ other.gameObject.name);
        if (other.GetComponent<RightHandIdentifier>())
        {
            Debug.Log("RightHand Entered");
            RightHandRay.SetActive(false);
            Controller.SetActive(true);
        }
        if (other.GetComponent<LeftHandIdentifier>())
        {
            Debug.Log("LeftHand Entered");  
           // LeftHandRay.SetActive(false);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Component Name: "+ other.gameObject.name);
        if (other.GetComponent<RightHandIdentifier>())
        {
           // Debug.Log("RightHand Exited");
            RightHandRay.SetActive(true);
            Controller.SetActive(false);
        }
        if (other.GetComponent<LeftHandIdentifier>())
        {
          //  Debug.Log("LeftHand Exited");
            //LeftHandRay.SetActive(true);
        }
    }

    public void DayClicked()
    {
        isDayActive = true;
        _dayView.SetActive(true);
        isWeekActive = false;
        _weekView.SetActive(false);
        isMonthActive = false;
        _monthView.SetActive(false);
    }
    public void WeekClicked()
    {
        isWeekActive = true;
        _weekView.SetActive(true);
        isDayActive = false;
        _dayView.SetActive(false);
        isMonthActive = false;
        _monthView.SetActive(false);
    }
    public void MonthClicked()
    {
        isMonthActive = true;
        _monthView.SetActive(true);
        isDayActive = false;
        _dayView.SetActive(false);
        isWeekActive = false;
        _weekView.SetActive(false);
    }
    
}
