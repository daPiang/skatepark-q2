using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float yaw=0.0f, pitch=0.0f;
    public Rigidbody rb;

    public Camera cam;

    public float speed = 0.0f, sens=2.0f, jump=5.0f;

    public LayerMask playerLayer;

    private bool gameOver = false;

    // Ray RayOrigin;
    // RaycastHit HitInfo;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb.gameObject.GetComponent<Rigidbody>();
        cam.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver) {

            isMoving();
            isGrounded();
            Look();
            
            // if(Input.GetKey(KeyCode.Space) && isGrounded() && isMoving()) {
            //     rb.velocity = new Vector3(rb.velocity.x,jump, rb.velocity.y);
            // }
            // Look();


            // Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.yellow);
            if(Input.GetKeyUp(KeyCode.E)) {
                if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, 2.5f, ~playerLayer)) {
                    // Debug.Log("Hit!");
                    if(hit.transform.CompareTag("Button")) {
                        // Debug.Log("Button");
                        hit.transform.SendMessage("useButton");
                    }
                }
            }

        }
    }

    private bool isMoving() {
        if(rb.velocity.x != 0 || rb.velocity.z != 0) {
            return true;
        } else {
            return false;
        }
    }

    private bool isGrounded() {
        if(Physics.Raycast(rb.transform.position, Vector3.down, 1 + 0.001f)) {
            return true;
        } else {
            return false;
        }
    }

    private void FixedUpdate() {
        if(!gameOver) {
            if(Input.GetKey(KeyCode.Space) && isGrounded() && isMoving()) {
                rb.velocity = new Vector3(rb.velocity.x,jump, rb.velocity.y);
            }
            Movement(); 
        }
    }

    private void Look() {
        pitch -= Input.GetAxisRaw("Mouse Y") * sens;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        yaw += Input.GetAxisRaw("Mouse X") * sens;
        cam.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);
    }

    private void Movement() {
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * speed;
        Vector3 fwd = new Vector3(-cam.transform.right.z, 0f, cam.transform.right.x);
        Vector3 wishDir = (fwd * axis.x + cam.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = wishDir;
    }

    public void GameOver() {
        gameOver = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
