using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region InputVariables
    public float horizontalInput;
    public float verticalInput;
    public bool jumpInput;
    private bool wantsToJump;
    private bool horizontalDown;
    private bool verticalDown;
    Transform camTransform;
    Vector3 camForward;
    Vector3 camRight;
    #endregion

    #region MovementVariables
    Rigidbody rb;
    [SerializeField]
    private float speed;
    public float maxSpeed;
    public float moveForce;
    public float jumpForce;
    public float acceleration;
    private Vector3 normalVector;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        camTransform = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        normalVector = new Vector3(0, 1, 0);
        rb.maxAngularVelocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
    }

    private void FixedUpdate() {

        if (horizontalDown || verticalDown)
            speed += acceleration;
        else
            speed -= acceleration;


        if (speed > maxSpeed)
            speed = maxSpeed;
        else if (speed < 0)
            speed = 0;
            

        rb.maxAngularVelocity = speed;

        rb.AddTorque((camForward * horizontalInput * -1 + camRight * verticalInput) * speed, ForceMode.VelocityChange);
        //rb.transform.Translate((camForward * horizontalInput * -1 + camRight * verticalInput) * speed, Space.World);
        //rb.transform.Rotate((camForward * horizontalInput * -1 + camRight * verticalInput) * speed, Space.World);
        
        //rb.AddTorque(camTransform.position.x * horizontalInput, 0, camTransform.position.z * verticalInput * -1);
        Jump();
        ApplyNormalGravity();

        //if (!horizontalDown) {
        //    if (rb.velocity.z != 0) {
        //        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Mathf.Lerp(rb.velocity.z, 0, 0.1f));
        //    }
        //}
        //if (!verticalDown) {
        //    if (rb.velocity.x != 0) {
        //        rb.velocity = new Vector3(Mathf.Lerp(rb.velocity.x, 0, 0.1f), rb.velocity.y, rb.velocity.z);
        //    }
        //}
    }

    void Jump() {
        
        if (wantsToJump) {
            rb.AddForce(normalVector * jumpForce, ForceMode.Impulse);
            wantsToJump = false;
        }
    }
    

    void InputManager() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        camForward = camTransform.forward;
        camRight = camTransform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        if (Input.GetButtonDown("Jump")) {
            wantsToJump = true;
        }
        if(horizontalInput != 0) {
            horizontalDown = true;
        }
        else {
            horizontalDown = false;
        }
        if (verticalInput != 0) {
            verticalDown = true;
        }
        else {
            verticalDown = false;
        }
    }

    void ApplyNormalGravity() {
        rb.AddForce(normalVector * -9.81f); 
    }

    public void OnCollisionStay(Collision collision) {
        if(collision.contacts.Length <= 1) {
            normalVector = collision.contacts[0].normal.normalized;
          
            //transform.up = normalVector;
        }
        else {
            normalVector = collision.contacts[collision.contacts.Length - 1].normal.normalized;
        }

    }

    private void OnDrawGizmos() {
        if (normalVector != null) {
            Vector3 forward = Vector3.forward;

            Vector3 right = Vector3.Cross(forward, normalVector);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + normalVector * 2.0f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + right * 2.0f);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + forward * 2.0f);
            Gizmos.color = Color.cyan;
            //Gizmos.DrawLine(transform.position, transform.position + Vector3.Cross((camTransform.forward * verticalInput), (camTransform.right * horizontalInput)));
            //Cambiar 2 componentes i de las 3 cambiar de signo

        }
    }


}
