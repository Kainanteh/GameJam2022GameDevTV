using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [HideInInspector] public ManagerAudio managerAudio;

    public PlayerTank ScriptPlayerTank;
    public PlayerControl ScriptPlayerControl;
    public Grid ScriptGrid;

    private void Awake() 
    {

        Instance = this;

        //managerAudio = this.GetComponent<ManagerAudio>();

    }

}
