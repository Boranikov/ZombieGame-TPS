using UnityEngine;

public class TargetB : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().ReachTargetB();
            Debug.Log("Target B'ye girildi!");
        }
    }
}
