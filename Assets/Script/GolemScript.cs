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

    public void ElevatorOpen()
    {

        GameManager.Instance.elevatorScript.setTrueElevatorFenceAnimation();
        // GameManager.Instance.ScriptGrid.MapAllowDirections[4, 2] = new int[] { 1, 1, 1, 1 };

        GameManager.Instance.ScriptGrid.GetCell(4,2).DirectionAllowed[0] = 1;
        GameManager.Instance.ScriptGrid.GetCell(4,2).DirectionAllowed[1] = 1;
        GameManager.Instance.ScriptGrid.GetCell(4,2).DirectionAllowed[2] = 1;
        GameManager.Instance.ScriptGrid.GetCell(4,2).DirectionAllowed[3] = 1;

    }

}
