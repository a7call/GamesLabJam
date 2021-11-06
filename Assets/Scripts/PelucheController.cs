using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelucheController : MonoBehaviour
{

    public MainPelucheController pelucheMain;

    public GameObject groupe1, groupe2;

    private Animator animator;

    private int typePelucheVoulue;

    public static bool bonnePeluche;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown("D"))
        {
            // Si on est bon 
            shufflePeluches();

            // sinon
            // AnimRaté
            
        }

        //On check si la bonne peluche est là
        bonnePeluche = (typePelucheVoulue == pelucheMain.getPelucheType());


    }

    public void changePeluche()
    {
        pelucheMain.changePeluche();
    }

    public void shufflePeluches()
    {

        //anim de shuffle du groupe de peluches
        animator.SetTrigger("Shuffle");
        //Changement de couleur/de sprite de la peluche
        

        //changement de la logique de la peluche
    }
}
