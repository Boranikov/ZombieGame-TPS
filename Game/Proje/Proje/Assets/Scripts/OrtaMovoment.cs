using UnityEngine;
using UnityEngine.AI;

public class OrtaMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    private NavMeshAgent agent;
    private Animator animator;
    private Health_Orta healthScript;

    [Header("Distances")]
    [SerializeField] private float walkDistance = 15f;
    [SerializeField] private float runDistance = 8f;
    [SerializeField] private float punchDistance = 2f;

    [Header("Speeds")]
    [SerializeField] private float walkSpeed = 1.5f;
    [SerializeField] private float runSpeed = 3.5f;

    [Header("Attack Settings")]
    [SerializeField] private float punchCooldown = 1.5f;
    [SerializeField] private int punchDamage = 25;  
    private float nextPunchTime = 0f;

    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        healthScript = GetComponent<Health_Orta>();

        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }

        if (agent != null)
            agent.stoppingDistance = punchDistance * 0.9f;
    }

    void Update()
    {
        if (isDead || healthScript == null || healthScript.IsDead) return;
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        bool isPunching = animator.GetBool("isPunching");

        if (!isPunching)
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

        if (distance > walkDistance)
            Idle();
        else if (distance > runDistance && distance <= walkDistance)
            Walk();
        else if (distance > punchDistance && distance <= runDistance)
            Run();
        else if (distance <= punchDistance)
            Punch();
    }

    void Idle()
    {
        if (agent != null) agent.isStopped = true;
        animator.SetFloat("speed", 0f);
        animator.SetBool("isPunching", false);
    }

    void Walk()
    {
        if (agent == null) return;
        agent.isStopped = false;
        agent.speed = walkSpeed;
        agent.SetDestination(player.position);
        animator.SetFloat("speed", 1f);
        animator.SetBool("isPunching", false);
    }

    void Run()
    {
        if (agent == null) return;
        agent.isStopped = false;
        agent.speed = runSpeed;
        agent.SetDestination(player.position);
        animator.SetFloat("speed", 2f);
        animator.SetBool("isPunching", false);
    }

    void Punch()
    {
        if (Time.time < nextPunchTime) return;

        if (agent != null) agent.isStopped = true;
        animator.SetBool("isPunching", true);

        nextPunchTime = Time.time + punchCooldown;
    }

    public void DealPunchDamage()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= punchDistance + 0.5f)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null && !playerHealth.IsDead())
            {
                playerHealth.TakeDamage(punchDamage);
                Debug.Log($"[Enemy] Oyuncuya {punchDamage} hasar verdi!");
            }
        }
    }


    public void StopPunch() => animator.SetBool("isPunching", false);

    public void OnDeath()
    {
        isDead = true;
        if (agent != null) agent.enabled = false;
    }
}
