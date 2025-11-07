using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyMovement : MonoBehaviour
{
    [Header("Hareket")]
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float gravity = 9.81f;

    [Header("Algılama / Saldırı")]
    [SerializeField] private float detectionRange = 14f;
    [SerializeField] private float attackRange = 2.2f;
    [SerializeField] private float attackCooldown = 2f;

    [Header("Saldırı Gücü")]
    [SerializeField] private int attackDamage = 15;

    private CharacterController controller;
    private Animator animator;
    private Transform player;
    private float yVel, nextAttackAllowed;
    private Health selfHealth;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        selfHealth = GetComponent<Health>();
    }

    void Start()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        player = p ? p.transform : null;

        if (animator)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isDead", false);
            animator.ResetTrigger("Attack");
        }
    }

    void Update()
    {
        if (selfHealth != null && selfHealth.IsDead) return;
        if (player == null || controller == null) return;

        Vector3 to = player.position - transform.position;
        Vector3 toXZ = new Vector3(to.x, 0f, to.z);
        float dist = toXZ.magnitude;

        if (controller.isGrounded) yVel = -1f;
        else yVel -= gravity * Time.deltaTime;

        Vector3 move = Vector3.zero;

        if (dist <= detectionRange && dist > attackRange)
        {
            Quaternion look = Quaternion.LookRotation(toXZ.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, look, 10f * Time.deltaTime);
            move = toXZ.normalized * moveSpeed;
            animator?.SetBool("isWalking", true);
        }
        else
        {
            animator?.SetBool("isWalking", false);
        }

        // 🔥 YAKINLIĞA GÖRE HASAR VERME
        if (dist <= attackRange && Time.time >= nextAttackAllowed)
        {
            animator?.SetTrigger("Attack");
            nextAttackAllowed = Time.time + attackCooldown;

            // PlayerHealth'i bul ve hasar ver
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null && !playerHealth.IsDead())
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }

        move.y = yVel;
        controller.Move(move * Time.deltaTime);
    }
}
