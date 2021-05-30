using UnityEngine;

public class TouchUse : MonoBehaviour
{
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log(hitInfo.collider.gameObject.name);
            }
        }
    }
}
