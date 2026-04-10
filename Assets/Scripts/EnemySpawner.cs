using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;  // Prefab do inimigo
    [SerializeField] Transform spawnPoint;    // Lugar onde aparece

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void Start()
    {
        // Crea o primeiro inimigo ao iniciar o xogo
        SpawnEnemy();
    }
}