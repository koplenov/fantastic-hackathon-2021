using System;
using UnityEngine;

public class ShopVoids : MonoBehaviour
{
    public GameObject tradeUi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            tradeUi.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            tradeUi.SetActive(false);
    }
}
