using UnityEngine;

public class PlayerAimCamera : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform cameraPivot;

    [Header("FOV")]
    [SerializeField] private float normalFOV = 60f;
    [SerializeField] private float aimFOV = 40f;

    [Header("Offsets (Local Position of Camera)")]
    [SerializeField] private Vector3 normalOffset = new Vector3(0f, 0.6f, -3.0f);
    [SerializeField] private Vector3 aimOffset = new Vector3(0.35f, 0.75f, -1.8f);

    [Header("Smooth")]
    [SerializeField] private float posLerp = 10f;
    [SerializeField] private float fovLerp = 10f;

    void Reset()
    {
        if (!playerCamera) playerCamera = GetComponentInChildren<Camera>();
        cameraPivot = transform;
    }

    void Start()
    {
        if (!playerCamera) playerCamera = GetComponentInChildren<Camera>();
        if (!cameraPivot) cameraPivot = transform;

        playerCamera.transform.localPosition = normalOffset;
        playerCamera.fieldOfView = normalFOV;
    }

    void Update()
    {
        bool isAimCamera = Input.GetMouseButton(1);

        Vector3 targetOffset = isAimCamera ? aimOffset : normalOffset;
        float targetFOV = isAimCamera ? aimFOV : normalFOV;

        playerCamera.transform.localPosition =
            Vector3.Lerp(playerCamera.transform.localPosition, targetOffset, Time.deltaTime * posLerp);

        playerCamera.fieldOfView =
            Mathf.Lerp(playerCamera.fieldOfView, targetFOV, Time.deltaTime * fovLerp);
    }
}
