using UnityEngine;

public class TargetA : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().ReachTargetA();
            Debug.Log("Target A'ya girildi!");
        }
    }
}
