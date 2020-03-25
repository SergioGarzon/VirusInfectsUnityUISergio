using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLigthColor : MonoBehaviour
{
    public Light light;
    private int color;

    void Start()
    {
        this.light = GetComponent<Light>();
    }

    void Update()
    {
        /*
        this.color = Random.Range(-1, 3);

        switch(this.color)
        {
            case (0): this.light.color = Color.white; break;
            case (1): this.light.color = Color.cyan; break;
            case (2): this.light.color = Color.green; break;

        }*/

        StartCoroutine("AutoTimeCalculator");
    }

    IEnumerable AutoTimeCalculator()
    {
        int i = 0;

        while(i < 1000)
        {
            i++;
        }
        
        yield return new WaitForSeconds(10f); ;
    }


}
