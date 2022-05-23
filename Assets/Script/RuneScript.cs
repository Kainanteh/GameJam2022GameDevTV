using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneScript : MonoBehaviour
{

    public bool Active = false;
    public int index = 0;

    public GameObject runeObject;

    public ExtractorMagicScript extractorScript;

    public void DeActive()
    {
        if (Active == false)
        {
            runeObject.SetActive(true);
            Active = true;
        }
        else
        {
            runeObject.SetActive(false);
            Active = false;
        }
    }

    public void Desactive()
    {
        runeObject.SetActive(false);
        Active = false;
    }

}
