using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FaceDirection { North, East, South, West }

public class PlayerTank : MonoBehaviour
{

    public int xGridPlayer = 0;
    public int zGridPlayer = 0;



    public FaceDirection directionPlayer;

    public bool movingPlayer = false;
    private Vector3 oldPositionPlayer;
    private Vector3 newPositionPlayer;
    public bool rotatingPlayer = false;
    private Quaternion oldRotationPlayer;
    private Quaternion newRotationPlayer;
    public float movingVelocity = 10f;
    public float rotatingVelocity = 10f;

    void Update()
    {

        //Debug.Log("estoy en " + ScriptGrid.GetCell(xGridPlayer, zGridPlayer));

        if (Input.GetKeyDown(KeyCode.W))
        {
            MovePlayerGrid(1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            directionPlayer = ChangePlayerDirection(FaceDirection.West);
            ChangePlayerDirectionObject();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MovePlayerGrid(-1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            directionPlayer = ChangePlayerDirection(FaceDirection.East);
            ChangePlayerDirectionObject();
        }

        // if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
        //    Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        // {
            
        // }

        if (Input.anyKeyDown)
        {
            //PrintPlayerPositionGrid();
            //Debug.Log(ScriptGrid.GetCell(xGridPlayer,zGridPlayer).name);

        }

        if(movingPlayer == true)
        {
            transform.position = Vector3.Lerp(oldPositionPlayer, newPositionPlayer, 
                movingVelocity * Time.deltaTime);
            if(transform.position == newPositionPlayer){ movingPlayer = false; }
            oldPositionPlayer = transform.position;
        }

        if (rotatingPlayer == true)
        {
            transform.rotation = Quaternion.Slerp(oldRotationPlayer, newRotationPlayer, 
                rotatingVelocity * Time.deltaTime);
            if (transform.rotation == newRotationPlayer) { rotatingPlayer = false; }
            oldRotationPlayer = transform.rotation;
        }

  
    }

    void PrintPlayerPositionGrid()
    {

        Debug.Log(xGridPlayer + " " + zGridPlayer);

    }

    public void MovePlayerGrid(int movement)
    {

        switch (directionPlayer)
        {

            case FaceDirection.North:
            {
                if (zGridPlayer + movement >= GameManager.Instance.ScriptGrid.height
                ||  zGridPlayer + movement < 0) { return; }
                if (GameManager.Instance.ScriptGrid.GetCell(xGridPlayer, zGridPlayer).DirectionAllowed[0] == 0) { return; }
                
                zGridPlayer += movement;
                break;
            }
            case FaceDirection.East:
            {
                if (xGridPlayer + movement >= GameManager.Instance.ScriptGrid.width
                ||  xGridPlayer + movement < 0) { return; }
                if (GameManager.Instance.ScriptGrid.GetCell(xGridPlayer, zGridPlayer).DirectionAllowed[1] == 0) { return; }
                    
                xGridPlayer += movement;
                break;
            }
            case FaceDirection.South:
            {
                if (zGridPlayer - movement < 0
                ||  zGridPlayer - movement >= GameManager.Instance.ScriptGrid.height) { return; }
                if (GameManager.Instance.ScriptGrid.GetCell(xGridPlayer, zGridPlayer).DirectionAllowed[2] == 0) { return; }

                zGridPlayer -= movement;
                break;
            }
            case FaceDirection.West:
            {
                if (xGridPlayer - movement < 0
                || xGridPlayer - movement >= GameManager.Instance.ScriptGrid.width) { return; }
                if (GameManager.Instance.ScriptGrid.GetCell(xGridPlayer, zGridPlayer).DirectionAllowed[3] == 0) { return; }
                    
                xGridPlayer -= movement;
                break;
            }

        }


        //if (xGridPlayer < 0 || xGridPlayer >= ScriptGrid.height || zGridPlayer < 0 || zGridPlayer >= ScriptGrid.width) { return; }

        MovePlayerObjectGrid(GameManager.Instance.ScriptGrid.GetCell(xGridPlayer, zGridPlayer).transform.position);
        GameManager.Instance.managerAudio.PlayAudio("movePlayer2");
    }

    void MovePlayerObjectGrid(Vector3 positionCell)
    {
        //this.transform.position = positionCell;
        oldPositionPlayer = transform.position;
        newPositionPlayer = positionCell;
        movingPlayer = true;
    }

    public FaceDirection ChangePlayerDirection(FaceDirection FaceInput)
    {

        switch(FaceInput)
        {

            case FaceDirection.East:
            {

                switch(directionPlayer)
                {

                    case FaceDirection.North:
                    {
                        return FaceDirection.East;
                    }
                    case FaceDirection.East:
                    {
                        return FaceDirection.South;
                    }
                    case FaceDirection.South:
                    {
                        return FaceDirection.West;
                    }
                    case FaceDirection.West:
                    {
                        return FaceDirection.North;
                    }

                }

                break;

            }
            case FaceDirection.West:
            {
                switch(directionPlayer)
                {

                    case FaceDirection.North:
                    {
                        return FaceDirection.West;
                    }
                    case FaceDirection.East:
                    {
                        return FaceDirection.North;
                    }
                    case FaceDirection.South:
                    {
                        return FaceDirection.East;
                    }
                    case FaceDirection.West:
                    {
                        return FaceDirection.South;
                    }

                }
                break;
            }

        }

        return FaceDirection.North;

    }

    public void ChangePlayerDirectionObject()
    {

        oldRotationPlayer = transform.rotation;
        rotatingPlayer = true;
        GameManager.Instance.managerAudio.PlayAudio("rotatePlayer1");

        switch (directionPlayer)
        {

            case FaceDirection.North:
            {
                newRotationPlayer = Quaternion.Euler(0f,0f,0f);
                break;
            }
            case FaceDirection.East:
            {
                newRotationPlayer = Quaternion.Euler(0f, 90f, 0f);
                break;
            }
            case FaceDirection.South:
            {
                newRotationPlayer = Quaternion.Euler(0f,180f, 0f);
                break;
            }
            case FaceDirection.West:
            {
                newRotationPlayer =  Quaternion.Euler(0f,-90f,0f);
                break;
            }

        }

    }

}
