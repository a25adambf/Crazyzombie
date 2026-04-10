using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    //Velocidad de la bala

    [SerializeField] float speed = 20f;

    //Referencia ao RigidBody
    Rigidbody rb;

    Vector3 direction;

    //Se ejecuta cuando se crea el objecto

    void Awake()
    {
        // Se guarda el RigidBody del mismo objecto
        rb = GetComponent<Rigidbody>();
    }

    //Llamado desde FireProjectiles al instanciar
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    //Se ejecuta el primer frame
    void Start()
    {
        //Se le dice a la física que la bala se mueve hacia delante a X velocidad
        rb.linearVelocity = transform.forward * speed;
    }
    // Se ejecuta cuando colisiona con algo
    void OnCollisionEnter(Collision collision)
    {
        //Se destruye el projectil completo
        Destroy(gameObject);
    }

      private void OnTriggerEnter(Collider collision)
    {
        //Destrúese o proxectil completo
        Destroy(gameObject);
    }
}