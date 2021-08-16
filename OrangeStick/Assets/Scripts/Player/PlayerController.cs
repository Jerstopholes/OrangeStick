using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Automatically attaches a CharacterController component if needed.
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // Settings 
    [Header("Movement Settings")] [Tooltip("The speed at which the player moves.")]
    [SerializeField] private float moveSpeed = 5.0f;

    [Header("Jump Settings")] [Tooltip("The height the player can jump to by default.")]
    [SerializeField] private float jumpHeight = 1.5f;

    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private Transform cam;

    private float smootVelocity;
    
    // Non-editable things
    private CharacterController _characterController;
    // Start is called before the first frame update
    private void Start()
    {
        // Get the character controller
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smootVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _characterController.Move(moveDir.normalized * (moveSpeed * Time.deltaTime));
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
