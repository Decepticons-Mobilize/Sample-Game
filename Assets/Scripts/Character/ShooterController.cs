using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;


public class ShooterController : MonoBehaviour
{
    // GameObject variables
    [SerializeField] protected Animator charAnimator;
    
    private CharacterController charController;


    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotateSpeed = 5.0f;

    protected virtual void Awake()
    {
        charController = GetComponent<CharacterController>();
        charAnimator = GetComponent<Animator>();
        
    }

    
    void FixedUpdate()
    {
        CharacterMoving();
    }

    void CharacterMoving()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        Vector3 movDirection = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 relativeMovDirection = transform.TransformDirection(movDirection);

        charAnimator.SetFloat("Speed", movDirection.magnitude);
        

        if (movDirection.sqrMagnitude > 0)
        {
            charAnimator.SetBool("Shoot", false);
            Vector3 movement = movDirection.normalized * speed;
            charController.SimpleMove(movement);

            Quaternion targetRotation = Quaternion.LookRotation(relativeMovDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotateSpeed);
        }
    }
}
