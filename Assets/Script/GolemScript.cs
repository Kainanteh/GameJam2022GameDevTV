using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemScript : MonoBehaviour
{
    public Animator GolemForgeAnimator;


    public void setTrueGolemOutAnimation()
    {
        GolemForgeAnimator.SetBool("golemout", true);
    }
}
