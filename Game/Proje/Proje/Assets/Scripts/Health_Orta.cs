using UnityEngine;
using UnityEngine.AI;

public class Health_Orta : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 175;
    [SerializeField] private float deathDelay = 3f;
    private int currentHealth;
    private bool isDead = false;

    private Animator animator;
    private NavMeshAgent agent;

    public bool IsDead => isDead;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        Debug.Log($"{gameObject.name} {amount} hasar ald�. Kalan can: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        if (agent != null) agent.isStopped = true;

        if (animator != null)
        {
            animator.SetBool("isDead", true);
        }

        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = false;

        OrtaMovement move = GetComponent<OrtaMovement>();
        if (move != null) move.OnDeath();

        Destroy(gameObject, deathDelay);
    }
}
