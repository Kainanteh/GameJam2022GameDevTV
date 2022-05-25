using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinSpawn : MonoBehaviour
{

    public GameObject coffinObject;

    public bool havecoffin = false;

    public Animator coffinSpawnAnimator;


    public void setTrueCoffinSpawnAnimation()
    {
        coffinSpawnAnimator.SetBool("coffinSpawn", true);
    }

 

}
