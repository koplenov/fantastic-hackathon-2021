using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject[] patrolWaypoints;
    
    private Transform target;
    private int wavepointindex = -1;
    public NavMeshAgent agent;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        EnemyTowardNextPos();
    }

    void Update () 
    {
        // agent is within a close range/touching target waypoint
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            EnemyTowardNextPos();
        }
    }

    void EnemyTowardNextPos ()
    {
        if(wavepointindex == patrolWaypoints.Length - 1)
        {
            wavepointindex = -1;
            //Destroy(gameObject);
        }
        else
        {
            // set destination to waypoint
            wavepointindex++;
            target = patrolWaypoints[wavepointindex].transform;
            agent.SetDestination(target.position);
        }
    }
}
