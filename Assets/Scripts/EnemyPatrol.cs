using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private string waypointGroupName = "WaypointGroup";
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 1f;

    private Transform[] waypoints;
    private int currentIndex = 1;
    private float waitTimer = 0f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        GameObject group = GameObject.Find(waypointGroupName);
        if (group == null)
        {
            Debug.LogError("WaypointGroup sahnede bulunamadý!");
            enabled = false;
            return;
        }

        waypoints = group.GetComponentsInChildren<Transform>();
        waypoints = System.Array.FindAll(waypoints, t => t != group.transform);

        if (waypoints.Length > 1)
            transform.position = waypoints[0].position;
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Transform target = waypoints[currentIndex];
        float step = speed * Time.deltaTime;

        // Hareket var mý kontrol et
        float distance = Vector3.Distance(transform.position, target.position);
        bool isMoving = distance > 0.05f;

        if (animator != null)
            animator.SetBool("isWalking", isMoving); // Animator parametresi

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (distance < 0.1f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                currentIndex = (currentIndex + 1) % waypoints.Length;
                waitTimer = 0f;
            }
        }
    }
}
