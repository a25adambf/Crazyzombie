using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Número de disparos necesarios para destruir ao inimigo
    const int HITS_TO_DIE = 3;

    // Contador de impactos recibidos
    int hitCount = 0;

    // Chámase cando outro collider entra neste trigger
    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos se o obxecto que entrou é unha bala
        if (other.CompareTag("Bullet"))
        {
            // Aumentamos o contador de impactos
            hitCount++;

            // Destruímos a bala completa (obxecto raíz do proxectil)
            Destroy(other.transform.root.gameObject);

            // Se alcanzamos o número máximo de impactos, destruímos ao inimigo
            if (hitCount >= HITS_TO_DIE)
            {
                Destroy(gameObject);
            }
        }
    }
}