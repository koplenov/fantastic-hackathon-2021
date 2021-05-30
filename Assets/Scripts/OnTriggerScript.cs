using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerScript : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    { if (other.CompareTag("Player"))
        DataHolder.LoadStore();
    }
}
