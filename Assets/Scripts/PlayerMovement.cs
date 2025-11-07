using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private Animator animator;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float gravity = 1.0f;

    private CharacterController controller;
    private float yVelocity = 0.0f;
    private bool isDead = false;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        if (!animator)
            animator = GetComponent<Animator>();
    }

    void Start()
    {
        if (animator)
        {
            animator.SetBool("isDead", false);
            animator.SetBool("isGrounded", true);
            animator.SetFloat("Speed", 0f);
        }
    }

    void Update()
    {
        if (isDead)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0f, v);
        Vector3 velocity = direction * moveSpeed;

        float moveDir = 0f;
        if (Mathf.Abs(h) > 0.1f)
            moveDir = h;
        else if (v < -0.1f)
            moveDir = 0.5f;

        animator.SetFloat("Direction", moveDir);


        if (controller.isGrounded)
        {
            yVelocity = -1f;
        }
        else
        {
            yVelocity -= gravity;
        }

        velocity.y = yVelocity;
        velocity = transform.TransformDirection(velocity);
        controller.Move(velocity * Time.deltaTime);


        float planarSpeed = new Vector3(controller.velocity.x, 0f, controller.velocity.z).magnitude;
        animator.SetFloat("Speed", planarSpeed, 0.1f, Time.deltaTime);
        animator?.SetBool("isGrounded", controller.isGrounded);
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;


        animator.SetBool("isDead", true);

        controller.enabled = false;

        CapsuleCollider capsule = GetComponent<CapsuleCollider>();
        if (capsule != null)
        {
            capsule.direction = 2; 
            capsule.center = new Vector3(0, 0.5f, 0); 
        }


        Invoke("DisablePlayer", 3f);
    }

    void DisablePlayer()
    {
        gameObject.SetActive(false);
    }
}