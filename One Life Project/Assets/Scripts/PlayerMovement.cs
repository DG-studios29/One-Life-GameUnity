using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f; // Speed of the player
    private Rigidbody rb;
    private CameraFollow cameraFollow;
    public Animator anim; // Animator for player animations

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraFollow = FindObjectOfType<CameraFollow>(); // Find the CameraFollow script

        if (anim == null)
        {
            anim = GetComponent<Animator>(); // Find the Animator component if not assigned
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 rotatedMovement = Quaternion.Euler(0, cameraFollow.currentRotationAngle, 0) * movement;

        if (movement.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
            rb.MovePosition(transform.position + rotatedMovement * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
