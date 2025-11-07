using UnityEngine;

public class HelicopterLanding : MonoBehaviour
{
    public float duration = 120f;
    public float startHeight = 10f;
    public float endHeight = 0f;

    private float elapsed = 0f;
    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        startPos = new Vector3(transform.position.x, startHeight, transform.position.z);
        endPos = new Vector3(transform.position.x, endHeight, transform.position.z);
    }

    void Update()
    {
        if (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(startPos, endPos, t);
        }
    }
}
