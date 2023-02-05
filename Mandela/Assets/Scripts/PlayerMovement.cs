using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSmoothTime;
    public float GravityStrength;
    public float JumpStregth;
    public float WalkSpeed;
    public float Runspeed;

    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDamoVelocity;

    private Vector3 CurrentForceVelocity; 

    
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        };
   
   if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }
   
        Vector3 MoveVector = transform.TransformDirection(PlayerInput);
        float CurrentSpeed = Input.GetKeyDown(KeyCode.LeftShift) ? Runspeed : WalkSpeed; 

        CurrentMoveVelocity = Vector3.SmoothDamp(
            CurrentMoveVelocity,
            MoveVector * CurrentSpeed,
            ref MoveDamoVelocity,
            MoveSmoothTime
        );

        Controller.Move(CurrentMoveVelocity * Time.deltaTime); 

       
    }
}
