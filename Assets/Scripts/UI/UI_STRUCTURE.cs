using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_STRUCTURE : MonoBehaviour
{
    public PlacementSystem placement_sys;

    public GameObject OpenButton;
    public GameObject CloseButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBuildMode()
    {
        placement_sys.BuildMode = true;
        CloseButton.SetActive(true);
        OpenButton.SetActive(false);
    }

    public void CloseBuildMode()
    {
        placement_sys.BuildMode = false;
        CloseButton.SetActive(false);
        OpenButton.SetActive(true);
    }

    public void SelectStructure(int index)
    {
        placement_sys.ID_index = index;
    }
}
