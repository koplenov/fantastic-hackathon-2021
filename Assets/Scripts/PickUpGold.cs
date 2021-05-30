using UnityEngine;
public class PickUpGold : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DataHolder.gold++;
            //print(DataHolder.gold);
            //other.gameObject.GetComponent<PlayerInventory>().gold++;
            //other.gameObject.GetComponent<Inventory>().UpdateUi();
            Destroy(gameObject);
        }
    }
}
       
