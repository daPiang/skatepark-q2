using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveDir;
    private Vector2 input;
    public float speed = 5f;
    public float jumpForce = 13f;
    public float antiBump = 4.5f;
    public float gravity = 30f;

    private void Awake() {
        controller = GetComponent<CharacterController>();
    }

    private void Start() {

    }

    private void Update() {
        Movement();
        isMoving();
    }
    
    private void FixedUpdate() {
        controller.Move(moveDir * Time.deltaTime);
    }

    private void Jump() {
        moveDir.y += jumpForce;
    }

    private bool isMoving() {
        if(input.x != 0 || input.y != 0) {
            return true;
        } else {
            return false;
        }
    }

    private void Movement() {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(input.x != 0 && input.y != 0) {
            input *= 0.777f;
            // moving = true;
        } else {
            // moving = false;
        }
        moveDir.x = input.x*speed;
        moveDir.z = input.y*speed;
        moveDir.y = -antiBump;
        moveDir = transform.TransformDirection(moveDir);
        if(Input.GetKey(KeyCode.Space) && controller.isGrounded && isMoving()) {
            Jump();
        } else {
            moveDir.y -= gravity * Time.deltaTime;
        }
    }
}
