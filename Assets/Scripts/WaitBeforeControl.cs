using System.Collections;
using UnityEngine;

public class WaitBeforeControl : MonoBehaviour
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
        enemy.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(waitInSec);
        enemy.GetComponent<PlayerController>().enabled = true;
    }
}
