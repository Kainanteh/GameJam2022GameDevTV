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


}
