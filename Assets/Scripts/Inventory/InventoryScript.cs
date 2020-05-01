using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public List<GameObject> prefabs;
    public GameObject panel;
    public Texture texturaEspanolAzul;
    public Texture texturaInglesAzul;
    public RawImage imagenAzul;
    
    public Texture texturaEspanolVerde;
    public Texture texturaInglesVerde;
    public RawImage imagenVerde;
    
    public Texture texturaEspanolVioleta;
    public Texture texturaInglesVioleta;
    public RawImage imagenVioleta;


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
            var controller = itemObject.GetComponent<ItemController>();
            controller.Load(si);
            prefabs.Insert(i, itemObject);
            itemObject.GetComponent<Button>().onClick.AddListener(()=>OnButtonClick(si));
        }
    }

    private void Update()
    {
    }


    public void LoadCards()
    {
        if (prefabs.Count != 0)
        {
            for (int i = 0; i < inventoryItem.Length; i++)
            {
                InventoryItem si = inventoryItem[i];
                GameObject itemObject = prefabs[i];
                var controller = itemObject.GetComponent<ItemController>();
                controller.Load(si);
            } 
        }
    }

    void OnButtonClick(InventoryItem item)
    {
        Debug.Log(item.name);

        if (this.VerificarLenguaje() == 0 && item.itemName=="Blue")
        {
            this.imagenAzul.texture = this.texturaInglesAzul;
            panel.gameObject.SetActive(true);
        }
        else if (item.itemName=="Blue")
        {
            this.imagenAzul.texture = this.texturaEspanolAzul;
            panel.gameObject.SetActive(true);
        }
        if (this.VerificarLenguaje() == 0 && item.itemName=="Green")
        {
            this.imagenVerde.texture = this.texturaInglesVerde;
            panel.gameObject.SetActive(true);
        }
        else if(item.itemName=="Green")
        {
            this.imagenVerde.texture = this.texturaEspanolVerde;
            panel.gameObject.SetActive(true);
        }
        if (this.VerificarLenguaje() == 0 && item.itemName=="Violet")
        {
            this.imagenVioleta.texture = this.texturaInglesVioleta;
            panel.gameObject.SetActive(true);
        }
        else if ( item.itemName=="Violet")
        {
            this.imagenVioleta.texture = this.texturaEspanolVioleta;
            panel.gameObject.SetActive(true);
        }

    }
    private int VerificarLenguaje()
    {
        int valor = 0;

        if (PlayerPrefs.HasKey("LenguajeGuardado"))
            valor = PlayerPrefs.GetInt("LenguajeGuardado", 0);

        return valor;
    }
}