using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    int layer_mask;
    PlayerTank PT_Script;

    [HideInInspector]
    public bool getCoffin = false;
    public GameObject objectCoffin;

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
                //Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                switch (hit.transform.name)
                {
                    /*
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
                    */
                    case "AtaudesSpawn":
                    {
                        TypeCellClass typeCC = GameManager.Instance.ScriptGrid.GetCell(GameManager.Instance.ScriptPlayerTank.xGridPlayer, 
                            GameManager.Instance.ScriptPlayerTank.zGridPlayer).Mytype;
                        if (typeCC.Type == TypeCell.CoffinSpawn && typeCC.TypeDirection == GameManager.Instance.ScriptPlayerTank.directionPlayer && getCoffin == false)
                        {
                            CoffinSpawn coffinScript = hit.transform.gameObject.GetComponent<CoffinSpawn>();
                            if (coffinScript.havecoffin == true)
                            {
                                coffinScript.coffinObject.SetActive(false);
                                coffinScript.havecoffin = false;
                                objectCoffin.SetActive(true);
                                getCoffin = true;
                                Debug.Log("Ha cogido un ataud");
                            }
                        }

                        break;
                    }
                    case "Cremator":
                    {
                        TypeCellClass typeCC = GameManager.Instance.ScriptGrid.GetCell(GameManager.Instance.ScriptPlayerTank.xGridPlayer,
                        GameManager.Instance.ScriptPlayerTank.zGridPlayer).Mytype;
                        if (typeCC.Type == TypeCell.Cremator && typeCC.TypeDirection == GameManager.Instance.ScriptPlayerTank.directionPlayer )
                        {
                            CrematorScript crematorScript = hit.transform.gameObject.GetComponent<CrematorScript>();
                            if (crematorScript.havecoffin == false && getCoffin == true)
                            {
                                crematorScript.coffinObject.SetActive(true);
                                crematorScript.havecoffin = true;
                                objectCoffin.SetActive(false);
                                getCoffin = false;
                                Debug.Log("Ha dejado un ataud");
                            }
                            else if(crematorScript.havecoffin == true && getCoffin == false)
                            {
                                if (crematorScript.finishedcoffin == true)
                                {
                                    crematorScript.coffinObject.SetActive(false);
                                    crematorScript.havecoffin = false;
                                    crematorScript.finishedcoffin = false;
                                    objectCoffin.SetActive(true);
                                    getCoffin = true;
                                    Debug.Log("Ha cogido un ataud magico");
                                }

                            }
                        }

                        break;
                    }

                }
            }
        }
    }

}
