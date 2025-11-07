using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField] private float sensitivity = 120f; 
    [SerializeField] private Transform cameraTarget;  
    [SerializeField] private float smoothTime = 0.1f;

    private float rotationYVelocity;
    private float currentYRotation;
    private float targetYRotation;

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");

        targetYRotation += mouseX * sensitivity * Time.deltaTime;

        currentYRotation = Mathf.SmoothDampAngle(currentYRotation, targetYRotation, ref rotationYVelocity, smoothTime);

        transform.rotation = Quaternion.Euler(0f, currentYRotation, 0f);
    }
}
