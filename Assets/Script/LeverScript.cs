using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
 
        public Animator LeverAnimator;


    public void setTrueLeverAnimation()
    {
        LeverAnimator.SetBool("levermove", true);
    }

}
