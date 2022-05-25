using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    int layer_mask;
    PlayerTank PT_Script;

    
    public bool getCoffin = false;
    public bool magicCoffing = false;

    public bool getPerla = false;

    public GameObject objectCoffin;
    public GameObject objectPerla;

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
                                //Debug.Log("Ha cogido un ataud");
                            }
                        }

                        break;
                    }
                    case "Cremator":
                    {
                        TypeCellClass typeCC = 
                            GameManager.Instance.ScriptGrid.GetCell
                                (GameManager.Instance.ScriptPlayerTank.xGridPlayer,
                            GameManager.Instance.ScriptPlayerTank.zGridPlayer).Mytype;
                        if (typeCC.Type == TypeCell.Cremator && typeCC.TypeDirection == 
                            GameManager.Instance.ScriptPlayerTank.directionPlayer )
                        {
                            CrematorScript crematorScript = hit.transform.gameObject.
                                GetComponent<CrematorScript>();
                            if (crematorScript.havecoffin == false && getCoffin == true 
                                && magicCoffing == false)
                            {
                                crematorScript.coffinObject.SetActive(true);
                                crematorScript.havecoffin = true;
                                objectCoffin.SetActive(false);
                                getCoffin = false;
                                //Debug.Log("Ha dejado un ataud");
                                crematorScript.setTrueCrematorAnimation();
                            }
                            else if(crematorScript.havecoffin == true && getCoffin == false)
                            {
                                if (crematorScript.finishedcoffin == true)
                                {
                                    //crematorScript.coffinObject.SetActive(false);
                                    crematorScript.coffinMagicoObject.SetActive(false);
                                    crematorScript.havecoffin = false;
                                    crematorScript.finishedcoffin = false;
                                    objectCoffin.SetActive(true);
                                    getCoffin = true;
                                    magicCoffing = true;
                                    //Debug.Log("Ha cogido un ataud magico");
                                }

                            }
                        }

                        break;
                    }
                    case "ExtractorMagic":
                    {
                        TypeCellClass typeCC = 
                            GameManager.Instance.ScriptGrid.GetCell
                                (GameManager.Instance.ScriptPlayerTank.xGridPlayer,
                            GameManager.Instance.ScriptPlayerTank.zGridPlayer).Mytype;
                        if (typeCC.Type == TypeCell.ExtractorMagic && typeCC.TypeDirection 
                            == GameManager.Instance.ScriptPlayerTank.directionPlayer)
                        {
                            ExtractorMagicScript extractorScript = hit.transform.gameObject.
                                GetComponent<ExtractorMagicScript>();
                            if (extractorScript.havecoffin == false && getCoffin == true 
                                && magicCoffing == true)
                            {
                                extractorScript.coffinMagicoObject.SetActive(true);
                                extractorScript.havecoffin = true;
                                objectCoffin.SetActive(false);
                                getCoffin = false;
                                //Debug.Log("Ha dejado un ataud magico");

                             

                            }
                            else if(extractorScript.havecoffin == true && getCoffin == false && 
                                extractorScript.haveperla == false && extractorScript.runepuzzle == true)
                            {
                                
                                extractorScript.perlaAlmaObject.SetActive(false);
                                extractorScript.setFalseOpenAnimation();
                                extractorScript.setTrueCloseAnimation();
                                getPerla = true;
                                objectPerla.SetActive(true);
                                extractorScript.Reset();
                                extractorScript.runepuzzle = false;

                            }
                        }

                        break;
                    }
                    case "GolemForge":
                    {
                        TypeCellClass typeCC = GameManager.Instance.ScriptGrid.GetCell(GameManager.Instance.ScriptPlayerTank.xGridPlayer,
                            GameManager.Instance.ScriptPlayerTank.zGridPlayer).Mytype;
                        if (typeCC.Type == TypeCell.Golem && typeCC.TypeDirection == GameManager.Instance.ScriptPlayerTank.directionPlayer)
                        {

                            GolemForgeScript golemforgeScript = hit.transform.gameObject.
                                GetComponent<GolemForgeScript>();
                            if(golemforgeScript.haveperla == false && getPerla == true)
                            {

                                golemforgeScript.perlaAlmaObject.SetActive(true);
                                golemforgeScript.haveperla = true;
                                objectPerla.SetActive(false);
                                getPerla = false;
                                golemforgeScript.GolemAnimator.SetBool("victory", true);

                            }

                        }

                        break;
                    }
                    case "Rune":
                    {

                        // Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                        RuneScript runeScript = hit.transform.gameObject.GetComponent<RuneScript>();
                        if(runeScript.extractorScript.havecoffin == true 
                            && runeScript.extractorScript.haveperla == false)
                        {
    
                            
                            runeScript.extractorScript.ActiveLeftRight(runeScript.index);
                            runeScript.extractorScript.CheckPuzzle();

                            if(runeScript.extractorScript.runepuzzle == true)
                            {
                                runeScript.extractorScript.setTrueOpenAnimation();
                                runeScript.extractorScript.perlaAlmaObject.SetActive(true);
                            }

                        }

                        break;
                    }
                    
                    


                }
            }
        }
    }

}
