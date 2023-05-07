using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody rb;
    public float Speed;
    public float RotSpeed;
    public float JumpValue = 4;
    public bool PlayerOnTheGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //Karakter Rotate
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Jump");
        Vector3 movementDir = new Vector3(x, 0, z);
        if (movementDir != Vector3.zero)
        {
            Quaternion toRot = Quaternion.LookRotation(movementDir, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, RotSpeed * Time.deltaTime);


        }// Zýplama
        if (Input.GetButtonDown("Jump") && PlayerOnTheGround) { 
            //rb.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse);
            rb.velocity = new Vector3(0, JumpValue, 0);
            PlayerOnTheGround = false;
        }

        }

    // Nerenin üstündeyken zýplamanýn aktif olacaðý
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            PlayerOnTheGround = true;
        }


//>>>>>>> 4fbf6e6e51efa786098569ad09e20011b690a1ab
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
