using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemForgeScript : MonoBehaviour
{

    public GameObject perlaAlmaObject;
  
    public bool haveperla = false;

    public Animator GolemForgeAnimator;
    public Animator GolemAnimator;

    public void setTrueGolemOutAnimation()
    {
        GolemForgeAnimator.SetBool("golemout", true);
    }

    public void PlayGolemOutRail()
    {
        GameManager.Instance.managerAudio.PlayAudio("golemoutrail");
    }

}
