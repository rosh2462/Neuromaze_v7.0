using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

private CharacterController controller;
private Vector3 playerVelocity;
private bool isGrounded;
public float speed=5f;
public float gravity=-9.8f;
public float jumpHeight=3f;
bool sprinting;
bool lerpCrouch;
float crouchTimer;
bool crouching;
    // Start is called before the first frame update
    void Start()
    {
        controller= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

       isGrounded= controller.isGrounded;
       if(lerpCrouch){
        crouchTimer+=Time.deltaTime;
        float p= crouchTimer/1;
        p*=p;
        if(crouching)
        controller.height=Mathf.Lerp(controller.height,1,p);
        else 
        controller.height=Mathf.Lerp(controller.height,2,p);
        if(p>1){
            lerpCrouch=false;
            crouchTimer=0f;

        }
       }
    }

    public void ProcessMove(Vector2 input){
        Vector3 moveDirection=Vector3.zero;
        moveDirection.x=input.x;
        moveDirection.z=input.y;
        controller.Move(transform.TransformDirection(moveDirection)*speed*Time.deltaTime);
        playerVelocity.y+=gravity*Time.deltaTime;
        if(isGrounded&&playerVelocity.y<0)
        playerVelocity.y=-2f;
        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }
    public void Jump(){
        if(isGrounded)
        {
            playerVelocity.y=Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }


    public void Crouch(){
        crouching= !crouching;
        crouchTimer=0;
        lerpCrouch=true;
    }
    public void Sprint(){
        sprinting= !sprinting;
        if (sprinting)
        speed=8;
        else
        speed=5;
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMotor : MonoBehaviour
// {
//     private CharacterController controller;
//     private Vector3 playerVelocity;
//     private bool isGrounded;
//     private float speed = 5f;
//     private float gravity = -9.8f;
//     private float jumpHeight = 3f;
//     private bool sprinting;
//     private bool lerpCrouch;
//     private float crouchTimer;
//     private bool crouching;
//     private bool isRunning;

//     private void Start()
//     {
//         controller = GetComponent<CharacterController>();
//     }

//     private void Update()
//     {
//         isGrounded = controller.isGrounded;

//         if (lerpCrouch)
//         {
//             crouchTimer += Time.deltaTime;
//             float p = crouchTimer / 1;
//             p *= p;
//             if (crouching)
//                 controller.height = Mathf.Lerp(controller.height, 1, p);
//             else
//                 controller.height = Mathf.Lerp(controller.height, 2, p);

//             if (p > 1)
//             {
//                 lerpCrouch = false;
//                 crouchTimer = 0f;
//             }
//         }

//         if (Input.GetKeyDown(KeyCode.LeftShift))
//         {
//             Sprint();
//         }

//         ProcessMovement();
//     }

//     private void ProcessMovement()
//     {
//         Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
//         Vector3 moveDirection = Vector3.zero;
//         moveDirection.x = input.x;
//         moveDirection.z = input.y;

//         float currentSpeed = speed;
//         if (isRunning)
//             currentSpeed *= 1.5f;

//         controller.Move(transform.TransformDirection(moveDirection) * currentSpeed * Time.deltaTime);

//         playerVelocity.y += gravity * Time.deltaTime;
//         if (isGrounded && playerVelocity.y < 0)
//             playerVelocity.y = -2f;

//         controller.Move(playerVelocity * Time.deltaTime);
//     }

//     public void Jump()
//     {
//         if (isGrounded)
//         {
//             playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
//         }
//     }

//     public void Crouch()
//     {
//         crouching = !crouching;
//         crouchTimer = 0;
//         lerpCrouch = true;
//     }

//     public void Sprint()
//     {
//         sprinting = !sprinting;
//         isRunning = sprinting;

//         if (sprinting)
//             speed = 8;
//         else
//             speed = 5;
//     }
// }
