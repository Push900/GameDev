using UnityEngine;

public class DragonController : MonoBehaviour
{
    public float speed = 5f;           // Visible in the Inspector
    public float turnSpeed = 100f;
    public Joystick joystick;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude > 0.1f)
        {
            Vector3 movement = direction.normalized * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);

            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, turnSpeed * Time.fixedDeltaTime);

            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
