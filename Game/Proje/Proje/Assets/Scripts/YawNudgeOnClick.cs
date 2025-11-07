using UnityEngine;

public class YawNudgeOnClick : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Bir t�kta eklenecek derece")]
    public float deltaDegrees = 50f;

    [Tooltip("Saniyedeki d�n�� h�z� (derece/sn)")]
    public float turnSpeedDegPerSec = 540f;

    [Tooltip("T�k bas�l� tutuldu�unda tekrar tekrar eklesin mi? (false = yaln�zca bas�ld��� an)")]
    public bool repeatWhileHeld = false;

    private float targetYaw;       
    private bool rotating = false;

    void Start()
    {
        targetYaw = transform.eulerAngles.y;
    }

    void Update()
    {
        bool left  = Input.GetMouseButtonDown(0) || (repeatWhileHeld && Input.GetMouseButton(0));
        bool right = Input.GetMouseButtonDown(1) || (repeatWhileHeld && Input.GetMouseButton(1));

        if (left || right)
        {
            targetYaw = NormalizeAngle(targetYaw + deltaDegrees);
            rotating = true;
        }

        if (rotating)
        {
            float currentYaw = transform.eulerAngles.y;
            float newYaw = Mathf.MoveTowardsAngle(currentYaw, targetYaw, turnSpeedDegPerSec * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, newYaw, 0f);

            if (Mathf.Abs(Mathf.DeltaAngle(newYaw, targetYaw)) < 0.01f)
                rotating = false;
        }
    }

    private float NormalizeAngle(float y)
    {
        y %= 360f;
        if (y < 0f) y += 360f;
        return y;
    }
}
