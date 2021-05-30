using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoFillStore : MonoBehaviour
{
    public List<Item> items;

    public Text superItem;
    public Text superItemCost;
    public Text swordItem;
    public Text swordItemCost;
    public Text armorItem;
    public Text armorItemCost;
    public Text potionItem;
    public Text potionItemCost;

    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        RandomItems();
        DisplaySlots();
    }

    // Update is called once per frame
    private void RandomItems()
    {
        var sword = gameObject.AddComponent<Sword>();
        sword.itemName = "Половник";
        sword.cost = Random.Range(3, 7);
        sword.damage = Random.Range(3, 10);
        sword.brokenness = Random.Range(3, 10);
        items.Add(sword);

        var armor = gameObject.AddComponent<Armor>();
        armor.itemName = "кожа(??)";
        armor.cost = Random.Range(3, 7);
        armor.contrDamage = Random.Range(3, 10);
        armor.brokenness = Random.Range(3, 10);
        items.Add(armor);
        
        var potion = gameObject.AddComponent<Potion>();
        potion.itemName = "Яд :3";
        potion.cost = Random.Range(8, 15);
        items.Add(potion);
        
        var superSword = gameObject.AddComponent<Sword>();
        superSword.itemName = "ВИИЛКА";
        superSword.cost = Random.Range(30, 70);
        superSword.damage = Random.Range(9, 19);
        superSword.brokenness = Random.Range(2, 15);
        items.Add(superSword);
    }
    
    
    private void DisplaySlots()
    {
        superItem.text = items[3].itemName;
        superItemCost.text = items[3].cost.ToString();
        
        swordItem.text = items[0].itemName;
        swordItemCost.text = items[0].cost.ToString();
        
        armorItem.text = items[1].itemName;
        armorItemCost.text = items[1].cost.ToString();
        
        potionItem.text = items[2].itemName;
        potionItemCost.text = items[2].cost.ToString();
    }
    
    
    #region Shop

    public Text OutResult;
    public Text damageInfo;
    public void BuySuperSword()
    {
        if (DataHolder.gold >= items[3].cost)
        {
            OutResult.text = successfully();
            DataHolder.gold -= items[3].cost;
            playerController.damage += 3;
            damageInfo.text = "Урон от твоего меча: " + playerController.damage;
        }
        else
        {
            OutResult.text = unsuccessfully();
        }
    }

    public void BuySword()
    {
        if (DataHolder.gold >= items[0].cost)
        {
            OutResult.text = successfully();
            DataHolder.gold -= items[0].cost;
            playerController.damage += 1;
            damageInfo.text = "Урон от твоего меча: " + playerController.damage;
        }
        else
        {
            OutResult.text = unsuccessfully();
        }
    }

    public void BuyArmor()
    {
        if (DataHolder.gold >= items[1].cost)
        {
            OutResult.text = successfully();
            DataHolder.gold -= items[1].cost;
        }
        else
        {
            OutResult.text = unsuccessfully();
        }
    }

    public void BuyPotion()
    {
        if (DataHolder.gold >= items[2].cost)
        {
            OutResult.text = successfully();
            DataHolder.gold -= items[2].cost;
        }
        else
        {
            OutResult.text = unsuccessfully();
        }
    }



    string successfully()
    {
        string[] ansers =
        {
            "приятно иметь дело",
            "по рукам!",
            "хмм, пойдет"
        };

        return ansers[Random.Range(0, ansers.Length)];
    }

    string unsuccessfully()
    {
        string[] ansers =
        {
            "ты бы еще консервных банок притащил",
            "это и все что ты можешь предложить?",
            "прости амиго, но нет"
        };

        return ansers[Random.Range(0, ansers.Length)];
    }

    #endregion
}
