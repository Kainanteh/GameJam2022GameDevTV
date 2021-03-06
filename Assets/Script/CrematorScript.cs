using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrematorScript : MonoBehaviour
{

    public GameObject coffinObject;
    public GameObject coffinMagicoObject;

    public bool havecoffin = false;
    public bool burningcoffin = false;
    public bool finishedcoffin = false;

    public float timeToTask = 10f;
    public float timeTask = 0f;

    public Animator CrematorAnimator;

    private void Update()
    {

        if (havecoffin == true && finishedcoffin == false)
        {

            burningcoffin = true;
            timeTask += Time.deltaTime;

            if(timeTask >= timeToTask)
            {
                timeTask = 0f;
                burningcoffin = false;
                finishedcoffin = true;
                coffinObject.SetActive(false);
                coffinMagicoObject.SetActive(true);
            }

        }

    }

    public void setTrueCrematorAnimation()
    {
        CrematorAnimator.SetBool("crematorCoffin", true);
    }

}
