using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRawImageTexture : MonoBehaviour
{
    public Texture textureButton1;
    public Texture textureOriginal;
    public RawImage imagen;

    void Start()
    {
        this.imagen.texture = this.textureOriginal;
    }

    private void Update()
    {
        /*
        if(this.imagen.texture == null)
            this.imagen.texture = this.textureButton1;*/
    }

    public void volverImagenMouseExit()
    {
        //this.imagen.texture = this.textureButton1;
        this.imagen.texture = this.textureOriginal;

    }

    
    public void cargarImageMouseEnter()
    {
        this.imagen.texture = this.textureButton1;

    }
    





}
