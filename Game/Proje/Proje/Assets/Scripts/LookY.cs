using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] private float sensitivity = 120f;
    [SerializeField] private float smoothTime = 0.1f;  
    [SerializeField] private float minY = -30f;        
    [SerializeField] private float maxY = 60f;         

    private float rotationXVelocity;
    private float currentXRotation;
    private float targetXRotation;

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        targetXRotation -= mouseY * sensitivity * Time.deltaTime;
        targetXRotation = Mathf.Clamp(targetXRotation, minY, maxY);

        currentXRotation = Mathf.SmoothDampAngle(currentXRotation, targetXRotation, ref rotationXVelocity, smoothTime);

        transform.localRotation = Quaternion.Euler(currentXRotation, 0f, 0f);
    }
}
