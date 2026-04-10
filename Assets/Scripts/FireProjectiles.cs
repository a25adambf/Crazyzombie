using UnityEngine;

public class FireProjectiles : MonoBehaviour
{
    [SerializeField] GameObject projectile;  // Objeto del proyectil
    [SerializeField] Transform firePoint; // Punto desde donde sale la bala
    [SerializeField] float delay; // Retardo antes de destruir el proyectil

    void Update()
    {
        //Fire1 = click izquierdo
        if (Input.GetButtonDown("Fire1"))
        { 
            // Se crea la bala en el FirePoint
            GameObject clone = Instantiate(
                projectile,
                firePoint.position,
                firePoint.rotation
            );

            // Se le dá la dirección correcta (del FirePoint)
            clone.GetComponent<ProjectileMovement>().SetDirection(firePoint.forward);
            // Destruir la bala sino colisiona 
            Destroy(clone, delay);
        }
    }
}