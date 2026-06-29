using UnityEngine;
using UnityEngine.AI;

public class MoveToPosition : MonoBehaviour
{
    Transform target;
    
    NavMeshAgent agent;

    void Start()
    {
        // Inicialçizase o compoñente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
          // Busca automaticamente ao xogador polo seu tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            target = player.transform;
    }

    void Update()
    {
        // Establécese o destino para que o axente calcule unha nova ruta
        agent.SetDestination(target.position);
    }
}