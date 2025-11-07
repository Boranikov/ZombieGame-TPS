using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 100;

    [Header("References")]
    [SerializeField] private Animator animator;

    private int currentHealth;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        if (!animator)
            animator = GetComponent<Animator>();

        if (animator)
        {
            animator.SetBool("isDead", false);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log($"[PlayerHealth] Damage: {damage} | Current HP: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;

        Debug.Log("[PlayerHealth] Player öldü!");

        PlayerMovement movement = GetComponent<PlayerMovement>();
        if (movement) movement.enabled = false;

        RifleWeapon weapon = GetComponent<RifleWeapon>();
        if (weapon) weapon.enabled = false;

        if (animator)
        {
            animator.SetBool("isDead", true);
        }

        StartCoroutine(FallToGround());
    }

    private System.Collections.IEnumerator FallToGround()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller == null)
        {
            yield break;
        }

        float fallSpeed = 0f;
        float gravity = 15f; 


        while (!controller.isGrounded || fallSpeed > 0.1f)
        {
            fallSpeed += gravity * Time.deltaTime;

            controller.Move(Vector3.down * fallSpeed * Time.deltaTime);

            yield return null;
        }

        controller.enabled = false;

        Debug.Log("[PlayerHealth] Karakter yere düştü.");
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);

        Debug.Log($"[PlayerHealth] Healed: {amount} | Current HP: {currentHealth}/{maxHealth}");
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public bool IsDead()
    {
        return isDead;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(25);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Heal(30);
        }
    }
}