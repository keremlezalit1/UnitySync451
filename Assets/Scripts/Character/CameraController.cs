using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Character;
    public Vector3 offSet;
    public float smoothValue;
    Vector3 refs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, Character.transform.position - offSet, ref refs, smoothValue);
    }
}
