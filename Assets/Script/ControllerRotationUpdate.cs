using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Sirenix.OdinInspector;
using UnityEngine;

public class ControllerRotationUpdate : MonoBehaviour
{
    [SerializeField] private GameObject pinchPoint;
    [SerializeField ]private IndexPinchSelector _pinchSelector;

    private Vector3 _startPoint;
    private Vector3 _endPoint;
    // Start is called before the first frame update
    void Start()
    {
        _startPoint = transform.position;
        _endPoint = new Vector3(transform.position.x + 2.0f, transform.position.y, transform.position.z);
       
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Rotaion : " + pinchPoint.transform.rotation);
        transform.rotation = Quaternion.Euler(-pinchPoint.transform.rotation.x, -pinchPoint.transform.rotation.y, -pinchPoint.transform.rotation.z);
        
       // if(_pinchSelector)
    }
    
    
    //DrawLine(_startPoint)
    
    
    
}
