using UnityEngine;

public class EnemyBite : MonoBehaviour
{
    // Tempo mínimo entre ataques
    float damageCooldown = 1f;

    // Momento no que poderá volver a facer dano
    float nextDamageTime;

    // Execútase cada frame mentres o xogador está dentro do trigger
    private void OnTriggerStay(Collider other)
    {
        // Comprobamos que sexa o xogador e que pasase o tempo de espera
        if (other.CompareTag("Jugador") && Time.time >= nextDamageTime)
        {
            // Chamamos ao método ApplyDamage do xogador
            other.SendMessage("ApplyDamage", 10);

            // Reiniciamos o temporizador de ataque
            nextDamageTime = Time.time + damageCooldown;
        }
    }
}