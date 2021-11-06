using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPelucheController : MonoBehaviour
{
    private int pelucheType;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = this.GetComponent<Renderer>().material;
        material.color = Color.black;

        
    }
    

    public void changePeluche(){
        int rand = (int) Random.Range(1,4);
        Debug.Log(rand);
        Color color = Color.white;
        switch (rand)
        {
            case 1 :
            color = Color.blue;
            pelucheType = 1;
                break;
            case 2 : 
            pelucheType = 2;
            color = Color.magenta;
                break;
            case 3 : 
            pelucheType = 3;
            color = Color.black;
                break; 
            default:
                break;
        }
        material.color = color;
    }

    public int getPelucheType()
    {
        return this.pelucheType;
    }
}
