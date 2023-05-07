using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField]
    PlacementSystem plSys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other && other.tag != "Plane")
        {
            plSys.IsOverSt = true;
            plSys.IsOverSt_Object = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        plSys.IsOverSt = false;
        plSys.IsOverSt_Object = null;
    }
}
