using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript: MonoBehaviour
{
    [Header("List of the items sold")] 
    public InventoryItem[] inventoryItem;

    [Header("References")] 
    public Transform inventoryContainer;

    public GameObject cardItemPrefab;

    public string amount;

    private void Start()
    {
        PopulateShop();
    }
    

    public void PopulateShop()
    {
        for (int i = 0; i < inventoryItem.Length; i++)
        {
            InventoryItem si = inventoryItem[i];
            GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer);

             itemObject.transform.GetChild(0).GetComponent<Image>().sprite= si.sprite;
            
             itemObject.transform.GetChild(1).GetComponent<Text>().text = si.itemName;
            
             amount = itemObject.transform.GetChild(2).GetComponent<Text>().text = ""+si.amount;
            
            itemObject.GetComponent<Button>().onClick.AddListener(()=>OnButtonClick(si));

        }
    }

    public void Update()
    {
        for (int i = 0; i < inventoryItem.Length; i++)
        {
            InventoryItem si = inventoryItem[i];
            amount = ""+si.amount;
        }
    }
    
    private void OnButtonClick(InventoryItem item)
    {
        Debug.Log(item.name);
    }
}