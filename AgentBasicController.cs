using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class AgentBasicController : Agent
{
    private Rigidbody rigidA;
    private float yThrust = 0.125f;
    private float moveSpeed = 0.5f;
    private float timer = 60f;
    public Transform inRay = null;
    [SerializeField] LayerMask rayMask;
    [SerializeField] public float rayRange;

    
    public void SensRay()
    {
        RaycastHit rayHit;
        if (Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.03929f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.078702f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.11836f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.15838f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.19891f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.24008f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.28203f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.32492f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.36892f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.41421f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.46101f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.50953f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.56003f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.6128f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.66818f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.72654f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.78834f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.85408f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,0.92439f)) * 50), out rayHit, rayRange, rayMask) ||

        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.92439f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.85408f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.78834f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.72654f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.66818f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.6128f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.56003f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.50953f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.46101f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.41421f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.36892f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.32492f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.28203f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.24008f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.19891f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.15838f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.11836f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.078702f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.03929f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.03929f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.078702f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.11836f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.15838f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.19891f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.24008f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.28203f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.32492f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.36892f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.41421f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.46101f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.50953f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.56003f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.6128f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.66818f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.72654f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.78834f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.85408f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.92439f)) * 50), out rayHit, rayRange, rayMask) ||

        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.92439f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.85408f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.78834f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.72654f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.66818f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.6128f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.56003f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.50953f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.46101f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.41421f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.36892f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.32492f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.28203f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.24008f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.19891f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.15838f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.11836f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.078702f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.03929f,0f,1f)) * 50), out rayHit, rayRange, rayMask) ||

        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,0f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.03929f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.078702f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.11836f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.15838f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.19891f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.24008f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.28203f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.32492f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.36892f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.41421f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.46101f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.50953f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.56003f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.6128f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.66818f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.72654f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.78834f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.85408f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.92439f)) * 50), out rayHit, rayRange, rayMask) ||

        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-1f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.92439f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.85408f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.78834f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.72654f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.66818f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.6128f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.56003f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.50953f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.46101f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.41421f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.36892f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.32492f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.28203f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.24008f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.19891f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.15838f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.11836f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.078702f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(-0.03929f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||

        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.03929f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.078702f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.11836f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.15838f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.19891f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.24008f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.28203f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.32492f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.36892f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.41421f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.46101f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.50953f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.56003f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.6128f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.66818f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.72654f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.78834f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.85408f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.92439f)) * 50), out rayHit, rayRange, rayMask) ||

        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(1f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.92439f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.85408f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.78834f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.72654f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.66818f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.6128f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.56003f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.50953f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.46101f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.41421f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.36892f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.32492f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.28203f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.24008f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.19891f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.15838f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.11836f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.078702f,0f,-1f)) * 50), out rayHit, rayRange, rayMask) ||
        Physics.Raycast(transform.localPosition, ((transform.TransformDirection(0.03929f,0f,-1f)) * 50), out rayHit, rayRange, rayMask))
        {
            inRay = rayHit.transform;

            //if (inRay.CompareTag("Goal"))
            //{
                //Vector3 target = inRay.localPosition;
                //Vector3 current = transform.localPosition;

                //transform.localPosition = Vector3.MoveTowards(current, target, moveSpeed);
            //}
            Debug.Log(inRay.name);
        }

        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0f)) * rayRange), Color.red);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.03929f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.078702f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.11836f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.15838f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.19891f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.24008f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.28203f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.32492f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.36892f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.41421f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.46101f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.50953f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.56003f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.6128f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.66818f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.72654f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.78834f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.85408f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,0.92439f)) * rayRange), Color.blue);

        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,1f)) * rayRange), Color.red);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.92439f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.85408f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.78834f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.72654f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.66818f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.6128f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.56003f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.50953f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.46101f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.41421f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.36892f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.32492f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.28203f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.24008f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.19891f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.15838f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.11836f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.078702f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.03929f,0f,1f)) * rayRange), Color.blue);
        
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0f,0f,1f)) * rayRange), Color.red);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.03929f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.078702f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.11836f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.15838f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.19891f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.24008f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.28203f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.32492f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.36892f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.41421f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.46101f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.50953f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.56003f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.6128f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.66818f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.72654f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.78834f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.85408f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0.92439f)) * rayRange), Color.blue);

        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,1f)) * rayRange), Color.red);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.92439f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.85408f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.78834f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.72654f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.66818f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.6128f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.56003f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.50953f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.46101f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.41421f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.36892f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.32492f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.28203f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.24008f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.19891f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.15838f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.11836f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.078702f,0f,1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.03929f,0f,1f)) * rayRange), Color.blue);

        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,0f)) * rayRange), Color.red);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.03929f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.078702f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.11836f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.15838f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.19891f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.24008f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.28203f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.32492f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.36892f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.41421f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.46101f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.50953f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.56003f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.6128f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.66818f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.72654f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.78834f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.85408f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-0.92439f)) * rayRange), Color.blue);

        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-1f,0f,-1f)) * rayRange), Color.red);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.92439f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.85408f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.78834f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.72654f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.66818f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.6128f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.56003f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.50953f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.46101f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.41421f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.36892f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.32492f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.28203f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.24008f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.19891f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.15838f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.11836f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.078702f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(-0.03929f,0f,-1f)) * rayRange), Color.blue);

        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0f,0f,-1f)) * rayRange), Color.red);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.03929f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.078702f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.11836f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.15838f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.19891f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.24008f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.28203f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.32492f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.36892f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.41421f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.46101f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.50953f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.56003f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.6128f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.66818f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.72654f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.78834f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.85408f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-0.92439f)) * rayRange), Color.blue);

        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(1f,0f,-1f)) * rayRange), Color.red);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.92439f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.85408f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.78834f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.72654f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.66818f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.6128f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.56003f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.50953f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.46101f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.41421f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.36892f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.32492f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.28203f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.24008f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.19891f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.15838f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.11836f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.078702f,0f,-1f)) * rayRange), Color.blue);
        Debug.DrawRay(transform.localPosition, ((transform.TransformDirection(0.03929f,0f,-1f)) * rayRange), Color.blue);        


    }


    public override void Initialize()
    {
        rigidA = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        rigidA = GetComponent<Rigidbody>();
    }

    public override void CollectObservations(VectorSensor sens)
    {
        sens.AddObservation(transform.localPosition);
        if (inRay != null) sens.AddObservation(inRay.localPosition);
    }
    
    public override void OnActionReceived(ActionBuffers acts)
    {
        int moveX = acts.DiscreteActions[0];
        int moveZ = acts.DiscreteActions[1];
        
        if (Mathf.FloorToInt(acts.DiscreteActions[2]) == 1)
        {
            Jump();
        }

        if (Mathf.FloorToInt(acts.DiscreteActions[3]) == 1)
        {
            SensRay();
        }

        Vector3 addForce = new Vector3(0, 0, 0);

        switch (moveX)
        {
            case 0: addForce.x = 0f; break;
            case 1: addForce.x = -1f; break;
            case 2: addForce.x = +1f; break;
        }

        switch (moveZ)
        {
            case 0: addForce.z = 0f; break;
            case 1: addForce.z = -1f; break;
            case 2: addForce.z = +1f; break;
        }

        rigidA.velocity = addForce * moveSpeed + new Vector3(0, rigidA.velocity.y, 0);
    }

    public override void Heuristic(in ActionBuffers actsOut)
    {
        ActionSegment<int> discreteActs = actsOut.DiscreteActions;

        switch (Mathf.RoundToInt(Input.GetAxisRaw("Horizontal")))
        {
            case -1: discreteActs[0] = 1; break;
            case 0: discreteActs[0] = 0; break;
            case +1: discreteActs[0] = 2; break;
        }

        switch (Mathf.RoundToInt(Input.GetAxisRaw("Vertical")))
        {
            case -1: discreteActs[1] = 1; break;
            case 0: discreteActs[1] = 0; break;
            case +1: discreteActs[1] = 2; break;
        }

        discreteActs[2] = 0;

        if (Input.GetKey(KeyCode.Space))
        {
            discreteActs[2] = 1;
        }

        discreteActs[3] = 0;

        if(Input.GetKey(KeyCode.R))
        {
            discreteActs[3] = 1;
        }
    }

    private void Jump()
    {
        if (transform.localPosition.y <= 1f)
        {
            rigidA.AddForce(new Vector3(0, yThrust , 0), ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            SetReward(+5f);
            EndEpisode();
            Debug.Log("+5");
        }
    
        if (other.CompareTag("Rift"))
        {
            SetReward(-1f);
            EndEpisode();
            Debug.Log("-1");
        }
    }



    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SetReward(-1F);
            timer = 60f;
            Debug.Log("Timer--");
        }
    }
    
}
