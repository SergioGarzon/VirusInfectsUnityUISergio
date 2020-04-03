using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//using Mono.Data.Sqlite;
using System.Data;
using System;


public class DataBase : MonoBehaviour
{

    void Start()
    {
        //Se queria crear una BASE DE DATOS pero no me deja instalar la referencia Mono.Data.Sqlite
        //esta instalada en los paquetes NuGet, PERO COMO QUE NO LA DETECTA

        string conn = "URL=file: " + Application.dataPath + "/Scripts/Controller/ADO/DataBase.cs";





    }
}
