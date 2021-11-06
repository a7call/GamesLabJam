using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelucheController : MonoBehaviour
{

    public MainPelucheController pelucheMain;

    public GameObject groupe1, groupe2;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            shufflePeluches();
            
        }

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
