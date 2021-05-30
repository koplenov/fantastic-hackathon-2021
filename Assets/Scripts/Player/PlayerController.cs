using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject focusedEnemy;

    public GameObject PointClick;

    public Animator animator;
    private Vector3 point;

    public int damage = 1;

    public Vector3 lastPosition;

    private void Start()
    {
        //DataHolder.startTime = DateTime.Now; назначаем в Awake в дейлике
        lastPosition = transform.position;

        StartCoroutine(GoldUpdate());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                switch (hitInfo.collider.tag)
                {
                    case "Enemy":
                        print("ВРАГ!1");
                        focusedEnemy = hitInfo.collider.gameObject;
                        StartCoroutine(Attack());
                        break;
                    
                    case "Shop":
                        //gameObject.BroadcastMessage("ShowOrHideShop", SendMessageOptions.DontRequireReceiver);
                        break;

                    default:
                        if (!tradeUi.activeSelf)
                        {
                            animator.SetBool("isWalk", true);
                            Instantiate(PointClick, hitInfo.point, Quaternion.identity);
                            GetComponent<NavMeshAgent>().SetDestination(hitInfo.point);
                            point = hitInfo.point;
                            
                            DataHolder.walkedDistance += Vector3.Distance(lastPosition, transform.position)/2;
                            lastPosition = transform.position;
                        }

                        break;
                }
            }
        }

        if(Vector3.Distance(point, transform.position) <= 4f)
            animator.SetBool("isWalk", false);
    }

    IEnumerator Attack()
    {
        var enemyHealth = focusedEnemy.GetComponent<Health>();
        
        animator.SetBool("isAttack", true);
        while (enemyHealth.health > 0)
        {
            transform.LookAt(focusedEnemy.transform);
            enemyHealth.health -= damage;
            yield return new WaitForSeconds(1.5f); // продолжить примерно через 100ms
        }
        animator.SetBool("isAttack", false);
        DataHolder.killedEnemy++;
        Destroy(focusedEnemy);
    }

    IEnumerator GoldUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if(DataHolder.gold <= 0)
                textGold.text = "В кошельке.. пусто?...";
            else
                textGold.text = "В кошельке:" + DataHolder.gold;
        }
    }


    #region UI
    
    public GameObject tradeUi;
    public GameObject openUi;
    public GameObject closeUi;
    public Text textGold;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shop"))
            openUi.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shop") && closeUi.activeSelf)
        {
            openUi.SetActive(false);
        }
    }


    public void OpenButton()
    {
        openUi.SetActive(false);
        tradeUi.SetActive(true);
    }
    
    public void CloseButton()
    {
        tradeUi.SetActive(false);
    }
    
    #endregion
}