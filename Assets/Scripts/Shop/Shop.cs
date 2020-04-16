using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("List of the items sold")] 
    [SerializeField]private ShopItem[] shopItems;

    [Header("References")] 
    [SerializeField] private Transform shopContainer;

    [SerializeField]private GameObject shopItemPrefab;

    private InventoryItem _inventoryItem;

    private void Start()
    {
        PopulateShop();
    }

    private void PopulateShop()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            ShopItem si = shopItems[i];
            GameObject itemObject = Instantiate(shopItemPrefab, shopContainer);

            itemObject.transform.GetChild(0).GetComponent<Image>().sprite= si.sprite;
            
            itemObject.transform.GetChild(1).GetComponent<Text>().text = si.itemName;
            
            itemObject.GetComponent<Button>().onClick.AddListener(()=>OnButtonClick(si));

        }
    }

    private void OnButtonClick(ShopItem item)
    {
        Debug.Log(item.name);
        //_inventoryItem.CalculateCardsValue();
        
        
        //comparar valor de tarjeta, tipo y el costo del producto
        //true= se agrega la funcionalidad en la batalla con bandera y restar amount
        //false = activar panel de no se puede comprar producto
    } 
}
