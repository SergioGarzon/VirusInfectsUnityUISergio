using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Player Charlie
 * Unit name: Hacker
 * Damage (año) = 100
 * unit level: 1
 * Max HP: 50
 * Current HP: 20
 * 
 * 
 * Unit name: Electroquinetico
 * Damage (Daño) : 100
 * unite level: 1
 * Max HP: 50
 * Current HP: 20
 * 
 * 
 * Unit name: Virus 1
 * Damage (daño): 20
 * Unit level: 1
 * Max HP: 20
 * Current HP: 0
 * 
 * 
 * Unit name: Virus 1 copy
 * Damage (daño): 20
 * Unit level: 1
 * Max HP: 20
 * Current HP: 1
 * 
 * 
 */

//Clase Unit es de unidad
public class Unit : MonoBehaviour
{

    //Variable donde declara el nombre del unidad
    public string unitName;

    //Variable string del daño recibido
    public string damage;

    //Variable entera del nivel de la unidad
    public int unitLevel;

    //Aqui tiene valor MAX HP
    public int maxHP;

    //Aqui tiene actual HP
    public int currentHP;


    //Metodo que retorna booleano verdadero o falso
    //Tomar daño, recibe por parametro un valor entero
    public bool TakeDamage(int dmg)
    {
        //variable actual HP
        currentHP -= dmg; //descuenta el daño sera
        //HP significa HEALT BAR
        
        //si la variable es menor o igual a 0(cero)
        if (currentHP <= 0)
        {
            //retorna verdadero
            return true;
        }
        else
        {
            //retorna falso
            return false;
        }
    }
}