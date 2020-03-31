using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentarEscalado : MonoBehaviour
{
    public RectTransform scroll;
   
    public void Aumentar_ButtonScale()
    {
        scroll.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void BajarEscalado()
    {
        scroll.localScale = new Vector3(1, 1, 1);
    }

}
