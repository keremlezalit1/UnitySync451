using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementSystem : MonoBehaviour
{
    [Header("Serialize Field izleme alaný")]
    [SerializeField]
    GameObject structureIndicator,cellIndicator;
    [SerializeField]
    InputManager inpManager;
    [SerializeField]
    Grid grid;
    [SerializeField]
    BuildingDB b_DB;
    [SerializeField]
    bool IsOverUI;
   
    [Header("Objects")]
    
    [Header("Bools")]
    public bool BuildMode;
    [Header("OffSets")]
    public Vector3 MouseoffSet;
    public Vector3 CelloffSet;
    [Header("Infos")]
    public int ID_index;
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


            if (Input.GetMouseButtonDown(0) && !IsOverUI && !IsOverSt)
            {
                var b = Instantiate(b_DB.container[ID_index].PREFAB);
                b.transform.position = mousePosInt - MouseoffSet;
            }
            else
            {
                
            }

            if (Input.GetMouseButtonDown(1) && IsOverSt && IsOverSt_Object)
            {

              if (IsOverSt_Object.tag == "Dirt")
              {
                  Debug.Log("FUCKER");
                  Destroy(IsOverSt_Object);
                  IsOverSt = false;
              }
                
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
    }
}
