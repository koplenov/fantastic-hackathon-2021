using System.Collections;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject eminem;
    private GameObject _enemyInstance;
    public GameObject[] patrolWaypoints;
    public Vector3 offsetSpawn = Vector3.up;

    private void Awake()
    {
        _enemyInstance = Instantiate(eminem, transform.position + offsetSpawn, Quaternion.identity);
        _enemyInstance.GetComponent<EnemyPatrol>().patrolWaypoints = patrolWaypoints;
        
        StartCoroutine(PointUpdate());
    }

    IEnumerator PointUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (_enemyInstance == null)
            {
                yield return new WaitForSeconds(10f);
                _enemyInstance = Instantiate(eminem, transform.position + offsetSpawn, Quaternion.identity);
                _enemyInstance.GetComponent<EnemyPatrol>().patrolWaypoints = patrolWaypoints;
            }
        }
    }
}
