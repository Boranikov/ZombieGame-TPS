using UnityEngine;

public class RifleWeapon : MonoBehaviour
{
    [Header("Referanslar")]
    [SerializeField] private Camera cam;
    [SerializeField] private Animator animator;

    [Header("Ateş Ayarları")]
    [SerializeField] private int damage = 20;
    [SerializeField] private float rayLength = 100f;
    [SerializeField] private float fireRate = 0.1f;

    private float nextFireTime = 0f;
    private bool cursorLocked = false;

    void Start()
    {
        if (!cam) cam = Camera.main;
        if (!animator) animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    if (Input.GetButton("Fire1") && Time.time >= nextFireTime && Cursor.lockState == CursorLockMode.Locked)
    {
        Fire();
        nextFireTime = Time.time + fireRate;
    }
}

    void Fire()
    {
        if (animator != null)
            animator.SetTrigger("FireTrig");

        if (cam == null) return;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit, rayLength))
        {
            Health hp = hit.collider.GetComponentInParent<Health>();
            if (hp != null)
                hp.TakeDamage(damage);
        }
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorLocked = true;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursorLocked = false;
    }
}