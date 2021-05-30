using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform ok;
    public Vector3 offset;
    void Update()
    {
        gameObject.transform.position = ok.position-offset;
    }
}
