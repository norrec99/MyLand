using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Gold Info")]
    [SerializeField] private int coinValue = 1;
    [Header("Vacuum Info")]
    [SerializeField] private float collectDistanceToPlayer = 1f;
    [SerializeField] private float vacuumSpeed = 20f;
    [SerializeField] private float kickUpSpeed = 30f;
    [SerializeField] private float playerSpeedMultiplier = 5f;

    private CapsuleCollider myCollider;
    private GameObject playerObj;
    private Vector3 verticalVel;
    private float currentSpeed;
    float fixedTimeFactor = 1f;
    PlayerMovementController playerMovementController;

    private void Awake()
    {
        myCollider = GetComponent<CapsuleCollider>();
        this.enabled = false;
        verticalVel = Vector3.up * kickUpSpeed;
        currentSpeed = vacuumSpeed;
    }
    private void Start()
    {
        playerObj = PlayerMovementController.Instance.gameObject;
    }
    private void FixedUpdate()
    {
        if ((transform.position - playerObj.transform.position).sqrMagnitude < collectDistanceToPlayer * collectDistanceToPlayer)
        {
            if (GameManager.Instance != null)
            {
                PlayerMovementController.Instance.CollectCoin(coinValue);
            }
            gameObject.SetActive(false);
            this.enabled = false;
            Destroy(gameObject, 1f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, playerObj.transform.position, currentSpeed * Time.deltaTime);
            transform.position += verticalVel * Time.fixedDeltaTime;
            verticalVel *= 1.0f - 0.05f * fixedTimeFactor;
            currentSpeed *= 1.0f + 0.05f * fixedTimeFactor;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.enabled = true;
            if (myCollider != null)
            {
                myCollider.enabled = false;
            }
            if (PlayerMovementController.Instance != null)
            {
                verticalVel += PlayerMovementController.Instance.GetMoveVector() * playerSpeedMultiplier;
            }
        }
    }
}
