using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [SerializeField] private RectTransform joystickOutline;
    [SerializeField] private RectTransform joystickButton;
    [SerializeField] private float moveFactor;

    private bool canControlJoystick;
    private Vector3 tapPosition;
    private Vector3 moveDirection;

    private void Start() 
    {
        HideJoystick();
    }
    private void Update() 
    {
        if (canControlJoystick)
        {
            ControlJoystick();
        }
    }
    public void TappedOnJoystickZone()
    {
        tapPosition = Input.mousePosition;
        joystickOutline.position = tapPosition;
        ShowJoystick();
    }
    private void ShowJoystick()
    {
        joystickOutline.gameObject.SetActive(true);
        canControlJoystick = true;
    }
    private void HideJoystick()
    {
        joystickOutline.gameObject.SetActive(false);
        canControlJoystick = false;
        moveDirection = Vector3.zero;
    }
    public void ControlJoystick()
    {
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - tapPosition;

        float canvasYScale = GetComponentInParent<Canvas>().GetComponent<RectTransform>().localScale.y;
        float moveMagnitude = direction.magnitude * moveFactor * canvasYScale;

        float joystickOutlineHalfWidth = joystickOutline.rect.width / 2;
        float newWidth = joystickOutlineHalfWidth * canvasYScale;

        moveMagnitude = Mathf.Min(moveMagnitude, newWidth);

        moveDirection = direction.normalized * moveMagnitude;

        Vector3 targetPosition = tapPosition + moveDirection;
        joystickButton.position = targetPosition;

        if (canControlJoystick)
        {
            if (Input.GetMouseButtonUp(0))
            {
                HideJoystick();
            }
        }
    }
    public Vector3 GetMovePosition()
    {
        return moveDirection / 1.5f;
    }
    public bool CanMove()
    {
        return canControlJoystick; 
    }
}
