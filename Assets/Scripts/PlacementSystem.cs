using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementSystem : MonoBehaviour
{
    [Header("Serialize Field izleme alaný")]
    [SerializeField]
    GameObject mouseIndicator,cellIndicator;
    [SerializeField]
    InputManager inpManager;
    [SerializeField]
    Grid grid;
    [SerializeField]
    BuildingDB b_DB;
    [SerializeField]
    bool IsOverUI;
    [SerializeField]
    GameObject Structure_Panel;

    [Header("Bools")]
    public bool BuildMode;
    [Header("OffSets")]
    public Vector3 MouseoffSet;
    public Vector3 CelloffSet;
    [Header("Infos")]
    public int ID_index;
    
    private void Update()
    {
        if (BuildMode)
        {
            Structure_Panel.SetActive(true);
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
            mouseIndicator.transform.position = mousePos - MouseoffSet;

            Vector3Int mousePosInt = new Vector3Int((int)mousePos.x, (int)mousePos.y, (int)mousePos.z);
            Vector3 gridPos = grid.CellToWorld(mousePosInt);
            cellIndicator.transform.position = gridPos - CelloffSet;

            
            if (Input.GetMouseButtonDown(0) && !IsOverUI && inpManager._hit.collider.tag == "Plane")
            {
                var b = Instantiate(b_DB.container[ID_index].PREFAB);
                b.transform.position = mousePosInt - MouseoffSet;
            }
            else
            {
                Debug.Log("Baþka obje var");
            }
        }
        else
        {
            Structure_Panel.SetActive(false);
        }
             
    }
}
