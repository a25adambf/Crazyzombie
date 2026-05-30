using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuración do Spawner")]
    [SerializeField] GameObject enemyPrefab;  // Prefab do inimigo
    [SerializeField] Transform spawnPoint;    // Lugar onde aparece
    [SerializeField] int maxEnemies = 10;      // Número máximo de zombies
    [SerializeField] KeyCode spawnKey = KeyCode.R; // Tecla para spawneear

    [Header("Referencias")]
    [SerializeField] Transform playerTarget;  // Obxectivo a perseguir (o xogador)

    int currentEnemyCount = 0;

    void Start()
    {
        // Spawneamos o primeiro inimigo ao iniciar
        SpawnEnemy();
    }

    void Update()
    {
        // Spawneear con tecla R (ata chegar ao máximo)
        if (Input.GetKeyDown(spawnKey) && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
        }

        // Spawneeo automático se hai menos de 5 zombies vivos (opcional)
        if (currentEnemyCount < 5 && currentEnemyCount < maxEnemies)
        {
            // Só spawneamos cada 3 segundos
            if (Time.time % 3f < Time.deltaTime)
            {
                SpawnEnemy();
            }
        }
    }

    public void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("EnemySpawner: enemyPrefab non asignado!");
            return;
        }

        if (currentEnemyCount >= maxEnemies) return;

        // Crear o inimigo
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Asignarlle o obxectivo (o xogador)
        MoveToPosition moveScript = enemy.GetComponent<MoveToPosition>();
        if (moveScript != null && playerTarget != null)
        {
            moveScript.SetTarget(playerTarget);
        }

        currentEnemyCount++;
        Debug.Log($"Zombie spawneado! Total: {currentEnemyCount}/{maxEnemies}");
    }

    // Método para cando un zombie morre
    public void OnEnemyDied()
    {
        currentEnemyCount = Mathf.Max(0, currentEnemyCount - 1);
        Debug.Log($"Zombie destruído! Restantes: {currentEnemyCount}/{maxEnemies}");
    }
}