using UnityEngine;

public class PointClick : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Destroy(gameObject);
        }
    }
}
