using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    private float rotationX = 0f;
    private Rigidbody rb;
    private bool cursorLocked = true;
    public bool start;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LockCursor(); // Verrouille le curseur dès le début
        Application.targetFrameRate = 144;
        start = true;
        StartCoroutine(Waiting());
        
    }

    void Update()
    {
        // Gestion du verrouillage du curseur
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleCursorLock();
        }

        // Rotation de la caméra
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = transform.right * moveX + transform.forward * moveZ;
        if (!start)
        {
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        }
        
    }

    private void ToggleCursorLock()
    {
        cursorLocked = !cursorLocked;
        LockCursor();
    }

    private void LockCursor()
    {
        Cursor.lockState = cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !cursorLocked;
    }

    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(11f);
        start = false;
    }
}

