using UnityEngine;

public class RotorSlowDown : MonoBehaviour
{
    public float startSpeed = 1500f; 
    public float duration = 120f;    
    private float elapsed = 0f;

    void Update()
    {
        if (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            float currentSpeed = Mathf.Lerp(startSpeed, 0f, t);

            transform.Rotate(Vector3.up * currentSpeed * Time.deltaTime, Space.Self);
        }
    }
}
