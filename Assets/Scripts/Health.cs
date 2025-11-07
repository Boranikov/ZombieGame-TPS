using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System;

public class Health : MonoBehaviour
{
    public static event Action OnEnemyDied;

    [Header("Health")]
    [SerializeField] private int maxHealth = 100;
    public int CurrentHealth { get; private set; }
    public bool IsDead { get; private set; }

    [Header("Animator Settings")]
    [SerializeField] private string idleStateName = "Idle";
    [SerializeField] private string dieStateName = "Die";
    [SerializeField] private string isDeadBool = "isDead";

    [Header("Death Options")]
    [SerializeField] private bool lockYOnDeath = true;
    [SerializeField] private float destroyDelay = 3f;

    private Animator animator;
    private CharacterController controller;
    private MonoBehaviour[] behaviours;
    private NavMeshAgent navMeshAgent;
    private float deathY;

    void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        behaviours = GetComponents<MonoBehaviour>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        CurrentHealth = maxHealth;
        IsDead = false;
        if (animator)
        {
            animator.applyRootMotion = false;
            animator.SetBool(isDeadBool, false);
            animator.SetBool("isWalking", false);
            animator.Play(idleStateName, 0, 0f);
        }
    }

    public void TakeDamage(int amount)
    {
        if (IsDead) return;
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        if (IsDead) return;
        IsDead = true;

        OnEnemyDied?.Invoke();

        if (animator)
        {
            animator.applyRootMotion = false;
            animator.SetBool("isWalking", false);
            animator.SetBool(isDeadBool, true);
            animator.Play(dieStateName, 0, 0f);
        }

        if (lockYOnDeath)
        {
            deathY = transform.position.y;
            StartCoroutine(StickToGround());
        }

        if (controller) controller.enabled = false;
        if (navMeshAgent) navMeshAgent.enabled = false;
        foreach (var mb in behaviours)
            if (mb != null && mb != this) mb.enabled = false;

        foreach (var c in GetComponentsInChildren<Collider>(true))
            c.enabled = false;

        Destroy(gameObject, destroyDelay);
    }

    private IEnumerator StickToGround()
    {
        while (true)
        {
            var p = transform.position;
            p.y = deathY;
            transform.position = p;
            yield return null;
        }
    }
}