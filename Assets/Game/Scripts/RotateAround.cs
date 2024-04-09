using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] bool turnLeft;
    [SerializeField] bool turnForward;
    [SerializeField] bool turnUp;
    [Header("Random Rotate")]
    [SerializeField] bool randomRotate;
    [SerializeField] float minRandomRotateValue;
    [SerializeField] float maxRandomRotateValue;
    [SerializeField] bool timerActive;
    [SerializeField] float stopTimer;
    float timer;
    bool stopTurn;

    float randomRotateX, randomRotateY, randomRotateZ;
    void Start()
    {
        randomRotateX = Random.Range(minRandomRotateValue, maxRandomRotateValue);
        randomRotateY = Random.Range(minRandomRotateValue, maxRandomRotateValue);
        randomRotateZ = Random.Range(minRandomRotateValue, maxRandomRotateValue);
    }
    void OnEnable()
    {
        stopTurn = false;
        timer = 0f;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(!timerActive)
        {
            if(turnForward)
            {
                transform.Rotate(Vector3.forward* Time.deltaTime * turnSpeed);
            }
            if(turnLeft)
            {
                transform.Rotate(Vector3.left* Time.deltaTime * turnSpeed);
            }
            if(turnUp)
            {
                transform.Rotate(Vector3.up* Time.deltaTime * turnSpeed);
            }
            if(randomRotate)
            {
                transform.Rotate(Vector3.forward* Time.deltaTime * randomRotateZ);
                transform.Rotate(Vector3.left* Time.deltaTime * randomRotateX);
                transform.Rotate(Vector3.up* Time.deltaTime * randomRotateY);
            }
        }
        else
        {
            if(timer > stopTimer)
            {
                stopTurn = true;
            }
            if(!stopTurn)
            {
                if(turnForward)
                {
                    transform.Rotate(Vector3.forward* Time.deltaTime * turnSpeed);
                }
                if(turnLeft)
                {
                    transform.Rotate(Vector3.left* Time.deltaTime * turnSpeed);
                }
                if(turnUp)
                {
                    transform.Rotate(Vector3.up* Time.deltaTime * turnSpeed);
                }
                if(randomRotate)
                {
                    transform.Rotate(Vector3.forward* Time.deltaTime * randomRotateZ);
                    transform.Rotate(Vector3.left* Time.deltaTime * randomRotateX);
                    transform.Rotate(Vector3.up* Time.deltaTime * randomRotateY);
                }
            }
        }
        
        
    }
    public void SetTurnSpeed(float speed)
    {
        turnSpeed = speed;
    }
}
