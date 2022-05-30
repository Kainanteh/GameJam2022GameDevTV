using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaTransicion : MonoBehaviour
{

    int layer_mask;
    public Animator TransicionAnimator;
    public AudioSource SonidoPuerta;

    private void Start() 
    {
        layer_mask = LayerMask.GetMask("Click");
    }

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f,layer_mask))
            {
                TransicionAnimator.SetBool("transicion", true);
            }
        }
    }

    public void PlayPuerta()
    {
        SonidoPuerta.Play(0);
    }

    public void CambiarEscena()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
