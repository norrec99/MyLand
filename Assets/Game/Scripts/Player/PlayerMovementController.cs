using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private JoystickController joystickController;
    [SerializeField] private PlayerAnimatorController playerAnimatorController;
    [SerializeField] private int moveSpeed;

    private Vector3 moveVector;

    private float gravity = -9.81f;
    private float gravityMultiplier = 3f;
    private float gravityVelocity;

    private CharacterController characterController;
    public static PlayerMovementController Instance;

    private void Awake() 
    {
        characterController = GetComponent<CharacterController>();    
        Instance = this;
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

        playerAnimatorController.ManageAnimations(moveVector);
        ApplyGravity();
        characterController.Move(moveVector);
    }
    private void ApplyGravity()
    {
        if (characterController.isGrounded && gravityVelocity < 0f)
        {
            gravityVelocity = -1f;
        }
        else
        {
            gravityVelocity += gravity * gravityMultiplier * Time.deltaTime;
            moveVector.y = gravityVelocity;
        }
    }
    
    public Vector3 GetMoveVector()
    {
        return moveVector;
    }
    public void CollectCoin(int coinValue)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCoin(coinValue);
        }
    }

}
