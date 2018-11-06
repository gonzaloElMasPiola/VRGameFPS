using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject enemyDestination;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            agent.SetDestination(enemyDestination.transform.position);
        }
       
	}
}
