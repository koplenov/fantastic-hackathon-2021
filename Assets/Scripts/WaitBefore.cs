using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WaitBefore : MonoBehaviour
{
    public GameObject enemy;
    public float waitInSec;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitBeforePatrol());
    }

    IEnumerator WaitBeforePatrol()
    {
        enemy.GetComponent<EnemyPatrol>().enabled = false;
        yield return new WaitForSeconds(waitInSec);
        enemy.GetComponent<EnemyPatrol>().enabled = true;
        
        enemy.GetComponent<BoxCollider>().enabled = true;
        enemy.GetComponent<NavMeshAgent>().enabled = true;
        
        
    }
}
