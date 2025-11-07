using UnityEngine;

public class AnimatorDebugger : MonoBehaviour
{
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError("[AnimatorDebugger] Animator yok!");
            return;
        }

        Debug.Log("[AnimatorDebugger] Animator bulundu: " + _anim.name);
        var controller = _anim.runtimeAnimatorController;
        if (controller == null)
        {
            Debug.LogError("[AnimatorDebugger] Controller atanmad� (runtimeAnimatorController null).");
            return;
        }

        Debug.Log("[AnimatorDebugger] Controller: " + controller.name + " | ClipCount: " + controller.animationClips.Length);

        foreach (var c in controller.animationClips)
        {
            Debug.Log("[AnimatorDebugger] Clip: " + c.name + "  length: " + c.length);
        }

        var parameters = _anim.parameters;
        Debug.Log("[AnimatorDebugger] Parametre say�s�: " + parameters.Length);
        foreach (var p in parameters)
        {
            Debug.Log($"[AnimatorDebugger] Param: {p.name}  type: {p.type}");
        }
    }
}
