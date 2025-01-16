using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject George;
    public float walkSpeed = 8f;
    public float sprintSpeed = 16f;
    private float currentSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkSpeed;  // Set the initial movement speed to walking speed
        GeorgeChill();
    }

    void Update()
    {
        Return();
        HandleSprint();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Get player input for horizontal and vertical movement (WASD/Arrow Keys)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Move the player using MovePosition (scaled by the current speed and Time.deltaTime for frame-rate independence)
        rb.MovePosition(rb.position + move * currentSpeed * Time.fixedDeltaTime);
    }

    void HandleSprint()
    {
        // Check if the sprint key is pressed/released
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = walkSpeed;
        }
    }

    IEnumerator HolOn()
    {
        yield return new WaitForSeconds(7f);
        George.SetActive(true);
    }

    public void GeorgeChill()
    {
        George.SetActive(false);
        StartCoroutine(HolOn());
    }

    void Return()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("FrontEnd");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
