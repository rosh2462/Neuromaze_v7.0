using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerInput.OnFootActions OnFoot;


    private PlayerMotor motor;
    private PlayerLook look;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput=new PlayerInput();
        OnFoot=playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look=GetComponent<PlayerLook>();
        OnFoot.Jump.performed += ctx => motor.Jump();

        OnFoot.Crouch.performed+=ctx=>motor.Crouch();
        //OnFoot.Sprint.performed+=ctx=>motor.Sprint();
    }

    // Update is called once per frame
    void Update()
    {
        motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());

    }
    private void LateUpdate(){
        look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());

    }

private void OnEnable()
    {
    OnFoot.Enable();

    }   

private void OnDisable()
    {
    OnFoot.Disable();
    }


}

