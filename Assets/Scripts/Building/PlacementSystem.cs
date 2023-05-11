using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PlacementSystem : MonoBehaviour
{
    [Header("Serialize Field izleme alaný")]
    [SerializeField]
    GameObject structureIndicator,cellIndicator;
    [SerializeField]
    InputManager inpManager;
    [SerializeField]
    Grid grid;
    
    [Header("DataBases")]
    public BuildingDB b_DB;
    public PlantDB plantDB;

    [Header("Objects")]
    GameObject notification_area;
    public GameObject Sample_Notification;
    public GameObject Sample_Ingame_Notification;
    
    [Header("Bools")]
    public bool BuildMode;
    public bool PlantMode;
    public bool IsOverUI;
    [Header("OffSets")]
    public Vector3 MouseoffSet;
    public Vector3 CelloffSet;
    [Header("Infos")]
    public int ID_index;
    public int PLANT_ID_index;
    public bool IsOverSt;

    public GameObject IsOverSt_Object;

    private void Update()
    {
        if (BuildMode)
        {
            
            structureIndicator.SetActive(true);
            cellIndicator.SetActive(true);

            //Event System ile mouse UI üzerinde mi deðilmi anlýyoruz
            if (EventSystem.current.IsPointerOverGameObject())
            {
                IsOverUI = true;
            }
            else
            {
                IsOverUI = false;
            }

            Vector3 mousePos = inpManager.GetMouseWorldPosition();
            structureIndicator.transform.position = mousePos - MouseoffSet;

            Vector3Int mousePosInt = new Vector3Int((int)mousePos.x, (int)mousePos.y, (int)mousePos.z);
            Vector3 gridPos = grid.CellToWorld(mousePosInt);
            cellIndicator.transform.position = gridPos - CelloffSet;


            #region Mouse Raycast
            Vector3 mousePos_ = Input.mousePosition;
            mousePos_.z = Camera.main.nearClipPlane;
            Ray ray = Camera.main.ScreenPointToRay(mousePos_);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
               
            }
            #endregion


            try
            {
                //Placement Something
                if (Input.GetMouseButtonDown(0) && !IsOverUI && !IsOverSt && !PlantMode)
                {
                    var b = Instantiate(b_DB.container[ID_index].PREFAB);
                    b.transform.position = mousePosInt - MouseoffSet;

                    //InGame Notification
                    var not = Instantiate(Sample_Ingame_Notification);
                    not.transform.position = b.transform.position + new Vector3(0,0.5f,0);
                    not.GetComponentInChildren<TextMeshProUGUI>().text = "Dirt +";
                   
                }
                //If there is Full
                if (Input.GetMouseButtonDown(0) && !IsOverUI && IsOverSt && !PlantMode)
                {
                    //Bildirim
                    var not = Instantiate(Sample_Notification, notification_area.transform);
                    not.GetComponentInChildren<TextMeshProUGUI>().text = "Area Full";
                    Debug.Log("Dolu");
                }         

                //Placement Plant
                if (Input.GetMouseButtonDown(0) && !IsOverUI && IsOverSt_Object.tag == "Dirt" && PlantMode)
                {
                    if (!IsOverSt_Object.transform.GetComponent<Dirt_Data>().IsPlanted)
                    {
                        var area = IsOverSt_Object.transform.GetChild(0);

                        var p = Instantiate(plantDB.container[PLANT_ID_index].PREFAB, area.transform);
                        p.transform.position = new Vector3(area.transform.position.x, area.transform.position.y, area.transform.position.z + 0.03f);
                        p.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        p.transform.localScale = new Vector3(1, 1, 1);
                        IsOverSt_Object.transform.GetComponent<Dirt_Data>().IsPlanted = true;

                    }

                }
                else
                {
                    Debug.Log("Dirt Yok");
                }

                // Destroy Dirt
                if (Input.GetMouseButtonDown(1) && IsOverSt && IsOverSt_Object && !PlantMode)
                {

                    if (IsOverSt_Object.tag == "Dirt")
                    {
                        Destroy(IsOverSt_Object);
                        IsOverSt = false;
                    }

                }
            }
            catch
            {

               
            }

            
        }
        else
        {
 


            structureIndicator.SetActive(false);
            cellIndicator.SetActive(false);
        }
             
    }

    private void Start()
    {
        IsOverSt = false;

        notification_area = GameObject.FindGameObjectWithTag("Notification");
    }
}
