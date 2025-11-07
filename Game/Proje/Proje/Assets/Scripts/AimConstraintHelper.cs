using UnityEngine;

public class AimConstraintHelper : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform aimTarget;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float aimDistance = 100f; 

    [Header("Settings")]
    [SerializeField] private float smoothSpeed = 10f;
    [SerializeField] private bool onlyAimWhenShooting = false; 

    [Header("Offset Settings")]
    [SerializeField] private Vector3 shoulderOffset = new Vector3(0.5f, 0f, 0f); 

    void Update()
    {
        if (aimTarget == null || mainCamera == null)
            return;

        if (onlyAimWhenShooting && !Input.GetMouseButton(0))
            return;

        Vector3 offset = mainCamera.right * shoulderOffset.x +
                         mainCamera.up * shoulderOffset.y +
                         mainCamera.forward * shoulderOffset.z;

        Vector3 targetPosition = mainCamera.position + mainCamera.forward * aimDistance + offset;

        aimTarget.position = Vector3.Lerp(
            aimTarget.position,
            targetPosition,
            Time.deltaTime * smoothSpeed
        );
    }
}
