using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAudio : MonoBehaviour
{

    [System.Serializable]
    public struct audiosVol {
        public AudioClip audioClip;
        public float volumen;
    }


    public audiosVol[] AudiosConVolumen;
    //public AudioClip[] audios;
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
            case "putGolemSoul":
            {
                index = 3;
                break;
            }
            case "runePress":
            {
                index = 4;
                break;
            }
            case "RISE":
            {
                index = 5;
                break;
            }
            case "ATMOS":
            {
                index = 6;
                break;
            }
            case "elevate":
            {
                index = 7;
                break;
            }
            case "getcoffin":
            {
                index = 8;
                break;
            }
            case "leavecoffin":
            {
                index = 9;
                break;
            }
            case "opencoffin":
            {
                index = 10;
                break;
            }
            case "lever":
            {
                index = 11;
                break;
            }
            case "golemoutrail":
            {
                index = 12;
                break;
            }
            case "error":
            {
                index = 13;
                break;
            }
        }


        if(index == -1){return;}
        //audioSource.PlayOneShot(audios[index]);
        audioSource.volume = AudiosConVolumen[index].volumen;
        audioSource.PlayOneShot(AudiosConVolumen[index].audioClip);

    }



}
