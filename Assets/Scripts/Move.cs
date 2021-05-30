using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.1f;
    // Update is called once per frame
    void FixedUpdate()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        transform.position += moveDirection * speed;

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 SaltoMortales = new Vector3(0.0f, 2.0f, 0.0f);
            transform.position += SaltoMortales;
        }
    }
}
