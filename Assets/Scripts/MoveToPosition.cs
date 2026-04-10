using UnityEngine;
using UnityEngine.AI;

public class MoveToPosition : MonoBehaviour
{
    [SerializeField] Transform target;
    
    NavMeshAgent agent;

    void Start()
    {
        // Inicializamos el componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Establecemos el destino para que el agente calcule una nueva ruta
        agent.SetDestination(target.position);
    }
}
