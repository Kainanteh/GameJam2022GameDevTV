using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
  
    public Animator ElevatorAnimator;



    public void setTrueElevatorFenceAnimation()
    {
        ElevatorAnimator.SetBool("fenceDoor", true);
    }

    public void setTrueElevatorElevateAnimation()
    {
        ElevatorAnimator.SetBool("elevate", true);
        
        GameManager.Instance.managerAudio.PlayAudio("RISE");
    }

    public void PlayAtmos()
    {
        GameManager.Instance.managerAudio.PlayAudio("ATMOS");
    }

    public void parentElevator()
    {
        GameManager.Instance.ScriptPlayerTank.transform.parent = this.transform;
    }

}
