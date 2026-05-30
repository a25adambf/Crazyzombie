using UnityEngine;
using UnityEngine.AI;

public class MoveToPosition : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float stoppingDistance = 1.5f; // Distancia á que se para
    [SerializeField] float updateInterval = 0.2f;   // Intervalo mínimo entre actualizacións de ruta
    
    NavMeshAgent agent;
    float lastUpdateTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.stoppingDistance = stoppingDistance;
        }
    
        // Se non hai target, busca ao xogador automaticamente
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Jugador");
            if (player != null)
                target = player.transform;
        }
    }

    void Update()
    {
        if (target == null || agent == null || !agent.isActiveAndEnabled) return;

        // Só actualizar o destino cada certo tempo para evitar sobrecarga
        if (Time.time - lastUpdateTime >= updateInterval)
        {
            agent.SetDestination(target.position);
            lastUpdateTime = Time.time;
        }
    }

    // Método público para asignar ou cambiar o obxectivo en tempo de execución
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}