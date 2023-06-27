using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    Rigidbody rb;  
    [SerializeField] float jumpForce = 5f;
    [SerializeField] AudioSource jumpSound;   
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    // Update is called once per frame

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f)* Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
         
        
        void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.CompareTag("enemyhead"))
            {
            Destroy(collision.transform.parent.gameObject);
            Jump();
            }
        }
        void Jump()
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            jumpSound.Play();
        }
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }  
    }
      
}
