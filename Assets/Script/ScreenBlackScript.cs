using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenBlackScript : MonoBehaviour
{

    public Animator ScreenBlackAnimator;
    public GameObject creador;

    public void setTrueScreenBlackAnimation()
    {
        ScreenBlackAnimator.SetBool("transition", true);
    }

    public void TrueCreador()
    {
        creador.SetActive(true);
    }
    public void FalseCreador()
    {
        creador.SetActive(false);
    }

}
