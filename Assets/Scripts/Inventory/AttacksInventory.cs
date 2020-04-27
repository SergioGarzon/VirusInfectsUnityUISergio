using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttacksInventory: MonoBehaviour
{
    [Header("List of the attacks")] 
    [SerializeField]private AttackItem[] inventoryItem;

    [Header("References")] 
    [SerializeField] private Transform inventoryContainer;

    [SerializeField]private GameObject cardItemPrefab;

    private void Start()
    {
        PopulateShop();
    }

    private void PopulateShop()
    {
        for (int i = 0; i < inventoryItem.Length; i++)
        {
            AttackItem si = inventoryItem[i];
            GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer);

            itemObject.transform.GetChild(0).GetComponent<Image>().sprite= si.sprite;
            
            itemObject.transform.GetChild(1).GetComponent<Text>().text = si.itemName;

            itemObject.GetComponent<Button>().onClick.AddListener(()=>OnButtonClick(si));

        }
    }
    

    private void OnButtonClick(AttackItem item)
    {
        Debug.Log(item.name);
    }
}