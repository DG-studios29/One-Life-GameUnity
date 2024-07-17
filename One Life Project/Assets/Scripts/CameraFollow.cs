using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0, 10, -10); // Offset position of the camera relative to the player
    public float rotationSpeed = 5f; // Speed of camera rotation

    public float currentRotationAngle = 0f; // Current rotation angle of the camera

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player by tag if not assigned
        }
    }

    void LateUpdate()
    {
        HandleMouseInput();
        UpdateCameraPosition();
        RotatePlayer();
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButton(1)) // Right mouse button for rotating the camera
        {
            float mouseX = Input.GetAxis("Mouse X");
            currentRotationAngle += mouseX * rotationSpeed;
        }
    }

    void UpdateCameraPosition()
    {
        // Calculate the new offset position based on the current rotation angle
        Quaternion rotation = Quaternion.Euler(0, currentRotationAngle, 0);
        Vector3 rotatedOffset = rotation * offset;

        // Update the camera's position and look at the player
        transform.position = player.position + rotatedOffset;
        transform.LookAt(player.position);
    }

    void RotatePlayer()
    {
        // Rotate the player to face the same direction as the camera
        player.rotation = Quaternion.Euler(0, currentRotationAngle, 0);
    }
}
