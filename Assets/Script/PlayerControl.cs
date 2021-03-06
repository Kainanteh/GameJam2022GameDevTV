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
                                GameManager.Instance.managerAudio.PlayAudio("getcoffin");
                            }
                            else
                            {
                                GameManager.Instance.managerAudio.PlayAudio("error");
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
                                GameManager.Instance.managerAudio.PlayAudio("leavecoffin");
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
                                    GameManager.Instance.managerAudio.PlayAudio("getcoffin");
                                }

                            }
                            else
                            {
                                GameManager.Instance.managerAudio.PlayAudio("error");
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
                                GameManager.Instance.managerAudio.PlayAudio("leavecoffin");

                             

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
                            else
                            {
                                GameManager.Instance.managerAudio.PlayAudio("error");
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
                                GameManager.Instance.managerAudio.PlayAudio("putGolemSoul");
                                

                            }
                            else
                            {
                                GameManager.Instance.managerAudio.PlayAudio("error");
                            }

                        }

                        break;
                    }
                    case "Rune":
                    {
                        
                        RuneScript runeScript = hit.transform.gameObject.GetComponent<RuneScript>();
                        if(runeScript.extractorScript.havecoffin == true 
                            && runeScript.extractorScript.haveperla == false)
                        {
    
                            runeScript.extractorScript.ActiveLeftRight(runeScript.index);
                            runeScript.extractorScript.CheckPuzzle();

                            GameManager.Instance.managerAudio.PlayAudio("runePress");

                            if(runeScript.extractorScript.runepuzzle == true)
                            {
                                runeScript.extractorScript.setTrueOpenAnimation();
                                runeScript.extractorScript.perlaAlmaObject.SetActive(true);
                            }

                        }
                        else
                        {
                            GameManager.Instance.managerAudio.PlayAudio("error");
                        }

                        break;
                    }
                    case "Lever":
                    {

                        TypeCellClass typeCC = GameManager.Instance.ScriptGrid.GetCell(GameManager.Instance.ScriptPlayerTank.xGridPlayer,
                            GameManager.Instance.ScriptPlayerTank.zGridPlayer).Mytype;
                        if (typeCC.Type == TypeCell.Lever && typeCC.TypeDirection == GameManager.Instance.ScriptPlayerTank.directionPlayer)
                        {

                            LeverScript leverScript = hit.transform.gameObject.GetComponent<LeverScript>();
                            leverScript.setTrueLeverAnimation();
                        
                            GameManager.Instance.coffinSpawnScript.setTrueCoffinSpawnAnimation();
                            GameManager.Instance.coffinSpawnScript.havecoffin = true;

                        }

                        break;
                    }
                    // default:
                    // {
                    //     GameManager.Instance.managerAudio.PlayAudio("error");
                    //     break;
                    // }
                }
            }
        }
    }
}


// Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object