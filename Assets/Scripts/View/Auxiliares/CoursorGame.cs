using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursorGame : MonoBehaviour
{
    public Texture2D textureImage;

    void Start()
    {
        Debug.Log(Application.dataPath);

        //Aqui lo que hace es definir el ancho y alto del cursor
        Vector2 vec = new Vector2(this.textureImage.width * 0.5f, this.textureImage.height * 0.5f);
        //Y aqui setea los valores del cursor
        Cursor.SetCursor(this.textureImage, vec, CursorMode.ForceSoftware);
    }
}
