using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    int layer_mask;
    PlayerTank PT_Script;

    private void Start() {
        layer_mask = LayerMask.GetMask("Click");
        PT_Script = GameManager.Instance.ScriptPlayerTank;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f,layer_mask))
            {
                 Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                switch (hit.transform.name)
                {
                    
                    case "W":
                    {
                        PT_Script.MovePlayerGrid(1);
                        break;
                    }
                    case "A":
                    {
                        PT_Script.directionPlayer = PT_Script.ChangePlayerDirection(FaceDirection.West);
                        PT_Script.ChangePlayerDirectionObject();
                        break;
                    }
                    case "S":
                    {
                        PT_Script.MovePlayerGrid(-1);
                        break;
                    }
                    case "D":
                    {
                        PT_Script.directionPlayer = PT_Script.ChangePlayerDirection(FaceDirection.East);
                        PT_Script.ChangePlayerDirectionObject();
                        break;
                    }
                    
                }
            }
        }
    }

}
