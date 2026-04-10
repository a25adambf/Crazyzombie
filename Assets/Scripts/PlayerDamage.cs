using UnityEngine;
using TMPro;

public class PlayerDamage : MonoBehaviour
{
    // Vida máxima do xogador
    [SerializeField] int maxHealth = 100;

    // Referencia ao texto da interface
    [SerializeField] TextMeshProUGUI txtHealth;

    // Vida actual
    int currentHealth;

    void Start()
    {
        // Inicializamos a vida e actualizamos a UI
        currentHealth = maxHealth;
        UpdateUI();
    }

    // Método que recibe o dano dende os inimigos
    public void ApplyDamage(int damage)
    {
        // Restamos a vida
        currentHealth -= damage;

        // Evitamos que baixe de 0
        currentHealth = Mathf.Max(currentHealth, 0);

        // Actualizamos o texto na pantalla
        UpdateUI();

        // Comprobamos se o xogador morreu
        if (currentHealth <= 0)
            Debug.Log("Player Morto");
    }

    // Actualiza o texto de vida na interface
    void UpdateUI()
    {
        txtHealth.text = "HP: " + currentHealth;
    }
}