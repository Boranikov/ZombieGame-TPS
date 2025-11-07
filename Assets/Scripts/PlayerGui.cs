using UnityEngine;

public class PlayerGui : MonoBehaviour
{
    [SerializeField] private Texture2D _crosshair;
    private bool isActive = false; // crosshair açýk mý?

    void OnGUI()
    {
        if (!isActive || _crosshair == null)
            return;

        float x = (Screen.width - _crosshair.width) / 2f;
        float y = (Screen.height - _crosshair.height) / 2f;

        GUI.DrawTexture(new Rect(x, y, _crosshair.width, _crosshair.height), _crosshair);
    }

    // GameManager'dan çaðrýlacak
    public void EnableCrosshair(bool value)
    {
        isActive = value;
    }
}
