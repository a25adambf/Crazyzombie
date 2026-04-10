using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed; // Velocidad del personaje

    void Start()
    {
        // Restringir el movimiento del ratón dentro de la ventana del juego
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Comprobar el movimiento del jugador
        Vector3 moveInput = Vector3.zero; // Inicializar el vector de movimiento a cero
        moveInput.x = Input.GetAxis("Horizontal") * speed; // Movimiento horizontal del personaje
        moveInput.z = Input.GetAxis("Vertical") * speed;   // Movimiento vertical del personaje
        moveInput *= Time.deltaTime; // Escalar el movimiento por el tiempo

        // Aplicar el movimiento al personaje en el plano XZ (suelo)
        transform.Translate(moveInput.x, 0, moveInput.z);

        // Liberar el ratón si se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
