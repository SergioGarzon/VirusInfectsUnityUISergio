using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Shop/ShopData")]
public class ShopData : ScriptableObject
{
    [SerializeField] private bool resettingSoldBool = false;
    [SerializeField] private bool healSoldBool = false;
    [SerializeField] private bool electroshockSoldBool = false;
    [SerializeField] private bool deleteSoldBool = false;
    [SerializeField] private bool controlzSoldBool = false;
    [SerializeField] private bool updateSoldBool = false;
    
    [NonSerialized] public bool resettingSold;
    [NonSerialized] public bool healSold;
    [NonSerialized] public bool electroshockSold;
    [NonSerialized] public bool deleteSold;
    [NonSerialized] public bool controlzSold;
    [NonSerialized] public bool updateSold;
    
    public void UpdateFlags()
    {
        resettingSold = resettingSoldBool;
        healSold = healSoldBool;
        electroshockSold = electroshockSoldBool;
        deleteSold = controlzSoldBool;
        updateSold = updateSoldBool;
    }
}
[Serializable]
public class SerializableFlags {
    private bool resettingSoldBool = false;
    private bool healSoldBool = false;
    private bool electroshockSoldBool = false;
    private bool deleteSoldBool = false;
    private bool controlzSoldBool = false;
    private bool updateSoldBool = false;
}

