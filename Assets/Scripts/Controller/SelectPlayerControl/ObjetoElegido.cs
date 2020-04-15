using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoElegido : MonoBehaviour
{
    public Text valorElegidoText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int x = PlayerPrefs.GetInt("ObjetoElegido", 0);

        if (x == 0)
            this.valorElegidoText.text = "ATIF";
        else
            this.valorElegidoText.text = "CHARLIE";

    }
}
