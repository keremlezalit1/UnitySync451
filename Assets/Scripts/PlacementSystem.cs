using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    GameObject mouseIndicator,cellIndicator;
    [SerializeField]
    InputManager inpManager;
    [SerializeField]
    Grid grid;
    [SerializeField]
    BuildingDB b_DB;

    public Vector3 MouseoffSet;
    public Vector3 CelloffSet;
    
    private void Update()
    {
        Vector3 mousePos = inpManager.GetMouseWorldPosition();
        mouseIndicator.transform.position = mousePos - MouseoffSet;

        Vector3Int mousePosInt = new Vector3Int((int)mousePos.x,(int)mousePos.y,(int)mousePos.z);
        Vector3 gridPos = grid.CellToWorld(mousePosInt);
        cellIndicator.transform.position = gridPos -CelloffSet;


        if (Input.GetMouseButtonDown(0))
        {
           var b = Instantiate(b_DB.container[0].PREFAB);
            b.transform.position = mousePosInt - MouseoffSet;
        }
    }
}
