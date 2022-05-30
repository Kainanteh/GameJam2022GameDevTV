using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
  
    public Animator ElevatorAnimator;

    public Transform PlayerT;
    public bool PlayerIn = false;

    public void setTrueElevatorFenceAnimation()
    {
        ElevatorAnimator.SetBool("fenceDoor", true);
    }

    public void setTrueElevatorElevateAnimation()
    {
        ElevatorAnimator.SetBool("elevate", true);
    }

    public void PlayRise()
    {
        GameManager.Instance.managerAudio.PlayAudio("RISE");
    }

    public void PlayAtmos()
    {
        GameManager.Instance.managerAudio.PlayAudio("ATMOS");
    }

    public void playerInElevator()
    {
        GameManager.Instance.elevatorScript.PlayerIn = true;
    }

    public void ToBlack()
    {

        GameManager.Instance.screenBlackScript.setTrueScreenBlackAnimation();

    }

    public void PlayAudioElevate()
    {
        GameManager.Instance.managerAudio.PlayAudio("elevate");
    }

    private void Update()
    {
        if(PlayerIn == true)
        {
            PlayerT.position = new Vector3(6.00177956f, this.transform.position.y , 4.00000286f);
        }
    }

    public void ExitGame()
    {

        GameManager.Instance.Exit();
        Debug.Log("Salida");

    }

}
