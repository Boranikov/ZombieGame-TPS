using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AimRigController : MonoBehaviour
{
    [Header("References")]
    public Rig aimRig;            
    public Animator animator;     

    [Header("Settings")]
    [Range(0f, 10f)] public float smoothSpeed = 5f;
    public string fireStateName = "Fire"; 

    private float targetWeight = 0f;

    void Update()
    {
      
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        bool isInFireState = stateInfo.IsName(fireStateName);

        targetWeight = isInFireState ? 1f : 0f;

        aimRig.weight = Mathf.Lerp(aimRig.weight, targetWeight, Time.deltaTime * smoothSpeed);
    }
}
