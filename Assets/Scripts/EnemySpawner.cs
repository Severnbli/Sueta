using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public string spawnPointTag = "SpawnPointForEnemies";
    public int maxEnemies = 3;
    public float spawnInterval = 20f;

    private Transform spawnPoint;

    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag(spawnPointTag).transform;

        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        }

        StartCoroutine(SpawnEnemiesPeriodically());
    }

    private void SpawnEnemy()
    {
        if (spawnPoint != null)
        {
            Vector2 randomOffset = Random.insideUnitCircle * 2f;
            Vector3 spawnPosition = spawnPoint.position + new Vector3(randomOffset.x, 0, randomOffset.y);

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private System.Collections.IEnumerator SpawnEnemiesPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            int currentEnemyCount = FindObjectsOfType<Enemy>().Length;

            if (currentEnemyCount < maxEnemies)
            {
                SpawnEnemy();
            }
        }
    }
}