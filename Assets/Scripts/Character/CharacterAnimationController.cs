using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    public Animator anim;

    public Transform LeftHand, RightHand; //{NOTE] -> In the final version the hands wont be needed here an instead only the Pole Targets will be set when interacting.
    public Transform LeftPole, RightPole;
    Vector3 orig_LeftPolePos, orig_RightPolePos;
    Quaternion orig_LeftPoleRot, orig_RightPoleRot;
    Transform LeftHold, RightHold;

    int currentAnimState = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
        orig_LeftPolePos = LeftPole.localPosition;
        orig_LeftPoleRot = LeftPole.localRotation;
        orig_RightPolePos = RightPole.localPosition;
        orig_RightPoleRot = RightPole.localRotation;
    }

    void Update()
    {

        //[NOTE] -> Old Animation Controller Code
        // If the character is moving backwards the velocity should be negative, and the animation should change.
        /*
        Vector3 velocityVector = rigid.velocity;
        float velocity;
        velocity = Mathf.Sqrt((velocityVector.x * velocityVector.x) + (velocityVector.z * velocityVector.z)); //X-Z Planar velocity of the rigidbody

        Vector3 angVelocityVector = rigid.angularVelocity;
        float angVelocity = angVelocityVector.y;

        if (smoothing)
        {
            velocity = Mathf.Lerp(lastVelocity, velocity, Mathf.SmoothStep(0.0f, 1.0f, Time.unscaledTime));
            angVelocity = Mathf.Lerp(lastAngVelocity, angVelocity, Mathf.SmoothStep(0.0f, 1.0f, Time.unscaledTime));
        }

        lastVelocity = velocity;
        lastAngVelocity = angVelocity;

        velocity = Mathf.Max(velocity, 0); //Velocity no less than 0

        anim.SetInteger("Gun", GunAnimState);

        
        if (inputController.IsMoving())
        {
            anim.SetBool("Running", true);

            GetDirectionFactors();

            r += velocity * speed / 100;
            if (r > 6.28318) r = 0;

            float blendFactor = Mathf.Clamp(velocity / physicsSpeed, -1, 1);

            anim.SetFloat("Sin", Mathf.Sin(r) * blendFactor * dirSign);
            anim.SetFloat("Cos", Mathf.Cos(r) * UpFrameWeight * blendFactor);
        }
        else 
        {
            anim.SetBool("Running", false);

            //When character not moving but is rotating
            r += angVelocity * speed / 30;
            if (r > 6.28318) r = 0;

            float blendFactor = Mathf.Clamp(angVelocity, -1,1);

            anim.SetFloat("Sin", Mathf.Sin(r) * blendFactor);
            anim.SetFloat("Cos", Mathf.Cos(r) * blendFactor);

            //anim.SetBool("Rotating", Mathf.Abs(angVelocity) > inputController.inputDeadzone);
        }
        */

        UpdatePoles();
    }

    private void FixedUpdate()
    {
        UpdateHands();
    }

    public void ResetHandTargets() {
        LeftPole.localPosition = orig_LeftPolePos;
        LeftPole.localRotation = orig_LeftPoleRot;
        RightPole.localPosition = orig_RightPolePos;
        RightPole.localRotation = orig_RightPoleRot;
        LeftHold = RightHold = null;
    }

    private void UpdatePoles()
    {
        if (LeftHold != null && RightHold != null)
        {
            LeftPole.position = LeftHold.position;
            LeftPole.rotation = LeftHold.rotation;
            RightPole.position = RightHold.position;
            RightPole.rotation = RightHold.rotation;
        }
    }

    private void UpdateHands() {
        LeftHand.position = LeftPole.position;
        LeftHand.rotation = LeftPole.rotation;

        RightHand.position = RightPole.position;
        RightHand.rotation = RightPole.rotation;
    }

    public void SetHandTransforms(Transform _LeftHold, Transform _RightHold)
    {
        LeftHold = _LeftHold;
        RightHold = _RightHold;
        //StartCoroutine(SlerpHandTransforms());
    }


    public void SetAnimState(int _state)
    {
        currentAnimState = _state;
        anim.SetInteger("Anim_State", currentAnimState);
    }

    public void SetAnimFloat(string _Property, float _value)
    {
        anim.SetFloat(_Property, _value);
    }

    public void SetAnimTrigger(string _Property)
    {
        anim.SetTrigger(_Property);
    }

    void GetDirectionFactors()
    {
        //dirSign = inputController.GetFowardSign();
        //anim.SetFloat("Strafe", inputController.GetStrafe());
    }
}

public enum Animation_State 
{ 
    Interacting,
    Combat
}

public enum Animation_Substate
{ 
    Gun,
    Tool,
    Throwable,
    Consumable
}

public enum Animation_Action
{ 
    
}
