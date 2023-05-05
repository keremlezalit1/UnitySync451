using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed;
    public float RotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Karakter Rotate
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movementDir = new Vector3(x, 0, z);
        if (movementDir != Vector3.zero)
        {
            Quaternion toRot = Quaternion.LookRotation(movementDir, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot,RotSpeed * Time.deltaTime);

        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Horizontal ve Vertical girdiyi bir Vector3'e verdik
        Vector3 movementDir = new Vector3(x, 0, z);

        //Hareket
        rb.MovePosition(transform.position + (movementDir * Speed * Time.deltaTime));

    }
}
