using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractorMagicScript : MonoBehaviour
{

    public GameObject coffinObject;
    public GameObject coffinMagicoObject;

    public GameObject perlaAlmaObject;

    public bool havecoffin = false;
    public bool haveperla = false;

    public Animator ExtractorMagicAnimator;

    public RuneScript[] runes = new RuneScript[6];
    public bool runepuzzle = false;


    public void setTrueDiscardAnimation()
    {
        ExtractorMagicAnimator.SetBool("DiscardCoffin",true);
    }
    public void setFalseDiscardAnimation()
    {
        ExtractorMagicAnimator.SetBool("DiscardCoffin", false);
        coffinMagicoObject.SetActive(false);
        havecoffin = false;
    }

    public void setTrueOpenAnimation()
    {
        ExtractorMagicAnimator.SetBool("OpenCoffin", true);
    }
    public void setFalseOpenAnimation()
    {
        ExtractorMagicAnimator.SetBool("OpenCoffin", false);
    }

    public void setTrueCloseAnimation()
    {
        ExtractorMagicAnimator.SetBool("CloseCoffin", true);
    }
    public void setFalseCloseAnimation()
    {
        ExtractorMagicAnimator.SetBool("CloseCoffin", false);
 
    }

    public void ActiveLeftRight(int index)
    {
        if (index == 0)
        {

            runes[index + 1].DeActive();

        }
        else if (index == runes.Length - 1)
        {

            runes[index - 1].DeActive();

        }
        else
        {

            runes[index + 1].DeActive();
            runes[index - 1].DeActive();

        }

    }

    public void CheckPuzzle()
    {
        int temp = 0;
        for (int i = 0; i < runes.Length; i++)
        {
            if (runes[i].Active == true) { temp++; }
        }
        if (temp == runes.Length)
        {
            runepuzzle = true;
        }

    }

    public void Reset()
    {

        for (int i = 0; i < runes.Length; i++)
        {
            runes[i].Desactive();
        }

        // runepuzzle = false;
     
    }

}
