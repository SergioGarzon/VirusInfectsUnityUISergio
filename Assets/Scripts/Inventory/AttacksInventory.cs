using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AttacksInventory: MonoBehaviour
{
    [Header("List of attacks")] 
    [SerializeField]private AttackItem[] inventoryItem;
    [SerializeField]private AttackItem[] selectedItem;

    [Header("References")] 
    [SerializeField] private Transform inventoryContainer;
    [SerializeField] private Transform attacksSelectedContainer;
    public ShopData shopData;
    public AttackItem CtrolZ;
    public AttackItem Reset;
    public AttackItem Delete;

    [SerializeField]private GameObject cardItemPrefab;

    private GameObject currentGameObject;
    private int selectedGrid;
    private bool gridIsChoosed = false;
    private string updateNameinventary;
    private  string updateNameSelected;

    private void Start()
    {
        PopulateShop();
        PopulateAttacks();
    }
    public void Update()
    {
        if (shopData.controlzSold) inventoryItem.Append(CtrolZ); PopulateShop();
        if (shopData.resettingSold) inventoryItem.Append(Reset);PopulateShop();
        if (shopData.deleteSold) inventoryItem.Append(Delete);PopulateShop();
    }

    private void PopulateShop()
    {
        for (int i = 0; i < inventoryItem.Length; i++)
        {
            AttackItem si = inventoryItem[i];
            GameObject itemObject = Instantiate(cardItemPrefab, inventoryContainer);

            itemObject.transform.GetChild(0).GetComponent<Image>().sprite= si.sprite;
            
            updateNameinventary=itemObject.transform.GetChild(1).GetComponent<Text>().text = si.itemName;

            itemObject.GetComponent<Button>().onClick.AddListener(()=>OnButtonClick(si));
            //currentGameObject = itemObject;

        }
    }
    private void PopulateAttacks()
    {
        for (int i = 0; i < selectedItem.Length; i++)
        {
            AttackItem si = selectedItem[i];
            GameObject itemObject = Instantiate(cardItemPrefab, attacksSelectedContainer);

            itemObject.transform.GetChild(0).GetComponent<Image>().sprite= si.sprite;
            
            updateNameSelected=itemObject.transform.GetChild(1).GetComponent<Text>().text = si.itemName;

            itemObject.GetComponent<Button>().onClick.AddListener(()=>OnButtonSelectedAttackClick(si));
        }
    }


    private void OnButtonClick(AttackItem item)
    {
        if (gridIsChoosed)
        {
            //ataque en el inventario
            string nombre = item.name;
            int id = item.id;
            Sprite sprite = item.sprite;
            
            //ataque seleccionado
            string nombreSeleccionado = selectedItem[selectedGrid].itemName;
            Sprite spriteSeleccionado = selectedItem[selectedGrid].sprite;
            
            //paso datos del seleccionado al del inventario
            item.name = nombreSeleccionado;
            item.id = selectedGrid;
            item.sprite = spriteSeleccionado;
            updateNameinventary = item.name;
            
            //paso datos del inventario al seleccionado
            selectedItem[selectedGrid].itemName= nombre;
            selectedItem[selectedGrid].sprite = sprite;
            selectedItem[selectedGrid].id = id;
            updateNameSelected = nombre;
            

            gridIsChoosed = false;
        }
        Debug.Log(item.name);
        UpdatingDates();
    }

    void OnButtonSelectedAttackClick(AttackItem item)
    {
        Debug.Log(item.id);
        selectedGrid = item.id;
        gridIsChoosed = true;
    }

    void UpdatingDates()
    {
        for (int i = 0; i < inventoryItem.Length; i++)
        {
            AttackItem si = inventoryItem[i];
            updateNameinventary= si.itemName;
        }
        for (int i = 0; i < selectedItem.Length; i++)
        {
            AttackItem si = selectedItem[i];
            updateNameSelected= si.itemName;
        }
    }
}