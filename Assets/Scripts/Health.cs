using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public GameObject Gold;
    private void LateUpdate()
    {
        if (health <= 0)
        {
            Instantiate(Gold, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
