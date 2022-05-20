using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAudio : MonoBehaviour
{


    public AudioClip[] audios;
    private AudioSource audioSource;

    private void Awake() 
    {

        audioSource = this.GetComponent<AudioSource>();

    }

    public void PlayAudio(string indexAudio)
    {
        int index=-1;
        switch (indexAudio)
        {
            case "movePlayer1":
            {
                index = 0;
                break;
            }
            case "movePlayer2":
            {
                index = 1;
                break;
            }
            case "rotatePlayer1":
            {
                index = 2;
                break;
            }
        }


        if(index == -1){return;}
        audioSource.PlayOneShot(audios[index]);
        
    }



}
