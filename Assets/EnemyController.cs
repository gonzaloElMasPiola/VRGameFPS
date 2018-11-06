using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject enemyDestination;
    public NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyDestination = GameObject.Find("Destination");
        agent.SetDestination(enemyDestination.transform.position);
    }

}
