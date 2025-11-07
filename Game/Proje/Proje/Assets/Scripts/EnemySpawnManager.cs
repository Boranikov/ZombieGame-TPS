using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject vardiyaliEnemyPrefab;    // Devriye yapan
    [SerializeField] private GameObject vardiyasizEnemyPrefab;   // Sabit duran

    [Header("Spawn Points")]
    [SerializeField] private Transform vardiyaliSpawnPoint;      // Tek nokta
    [SerializeField] private Transform[] vardiyasizSpawnPoints;  // Sabit noktalar

    [Header("Settings")]
    [SerializeField] private float spawnDelay = 1.5f;
    [SerializeField] private int maxEnemies = 20;

    private float nextSpawnTime = -1f;
    private int spawnedCount = 0;

    void Update()
    {
        if (spawnedCount < maxEnemies && Time.time >= nextSpawnTime)
        {
            bool spawnVardiyali = Random.value > 0.5f;

            if (spawnVardiyali)
            {
                // Devriye yapan zombiyi tek noktadan oluþtur
                Instantiate(vardiyaliEnemyPrefab, vardiyaliSpawnPoint.position, vardiyaliSpawnPoint.rotation);
            }
            else if (vardiyasizSpawnPoints.Length > 0)
            {
                // Sabit zombiyi rastgele bir noktada oluþtur
                Transform randomPoint = vardiyasizSpawnPoints[Random.Range(0, vardiyasizSpawnPoints.Length)];
                Instantiate(vardiyasizEnemyPrefab, randomPoint.position, randomPoint.rotation);
            }

            spawnedCount++;
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
