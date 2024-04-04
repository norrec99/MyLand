using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private JoystickController joystickController;
    [SerializeField] private PlayerAnimatorController playerAnimatorController;
    [SerializeField] private int moveSpeed;

    private Vector3 moveVector;

    private CharacterController characterController;

    private void Awake() 
    {
        characterController = GetComponent<CharacterController>();    
    }
    private void Update() 
    {
        MovePlayer();    
    }
    private void MovePlayer()
    {
        moveVector = joystickController.GetMovePosition() * moveSpeed * Time.deltaTime / Screen.width;

        moveVector.z = moveVector.y;
        moveVector.y = 0;

        characterController.Move(moveVector);
        playerAnimatorController.ManageAnimations(moveVector);
    }

}
