using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField] private Rigidbody playerRigidbody;

    [SerializeField]
    private Transform playerEyesTransform;

    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private float yawRotationSpeed;

    [SerializeField]
    private float pitchRotationSpeed;

    [SerializeField] private LineRenderer gunLineRenderer;
    [SerializeField] private Transform gunPosition;

    private Vector3 lastDirectionIntent;

    private float mouseInputX;
    private float mouseInputY;
    private bool mouseClick;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    private void Update()
    {
        lastDirectionIntent = Vector3.zero;

        mouseInputX = Input.GetAxis("Horizontal");
        mouseInputY = Input.GetAxis("Vertical");
        mouseClick = Input.GetMouseButton(0);

        if (Input.GetKey(KeyCode.D))
        {
            lastDirectionIntent += playerTransform.right;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            lastDirectionIntent -= playerTransform.right;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            lastDirectionIntent += playerTransform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            lastDirectionIntent -= playerTransform.forward;
        }

        lastDirectionIntent = lastDirectionIntent.normalized;
    }

    private void FixedUpdate()
    {
        playerTransform.RotateAround(playerTransform.position, playerTransform.up , mouseInputX * yawRotationSpeed * Time.fixedDeltaTime);
        playerEyesTransform.RotateAround(playerEyesTransform.position, playerEyesTransform.right ,-mouseInputY * pitchRotationSpeed * Time.fixedDeltaTime);

        var rotationX = playerEyesTransform.rotation.eulerAngles.x;
        if (rotationX > 180f)
        {
            rotationX = -360f + rotationX;
        }
        
        playerEyesTransform.localRotation = Quaternion.Euler(
            Mathf.Clamp(rotationX, -80f, 80f),
            0f,
            0f);
        
        playerRigidbody.MovePosition(playerRigidbody.position  + lastDirectionIntent * (Time.fixedDeltaTime * playerSpeed));

        if (mouseClick)
        {
            RaycastHit hit;
            if (Physics.Raycast(playerEyesTransform.position, playerEyesTransform.forward, out hit))
            {
                //Debug.DrawLine(playerEyesTransform.position, hit.point);
                gunLineRenderer.enabled = true;
                gunLineRenderer.SetPosition(0, gunPosition.position);
                gunLineRenderer.SetPosition(1, hit.point);
            }
        }
        else
        {
            gunLineRenderer.enabled = false;
        }
    }
}
