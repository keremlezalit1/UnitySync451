using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_STRUCTURE : MonoBehaviour
{
    public PlacementSystem placement_sys;

    public GameObject OpenButton;
    public GameObject CloseButton;
    public GameObject Others;
    public GameObject BuildPanel;
    public GameObject PlantPanel;
    public GameObject ChoisePanel;

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
        Others.SetActive(true);
        ChoisePanel.SetActive(true);
        OpenButton.SetActive(false);
    }

    public void CloseBuildMode()
    {
        placement_sys.BuildMode = false;
        CloseButton.SetActive(false);
        Others.SetActive(false);
        ChoisePanel.SetActive(false);
        BuildPanel.SetActive(false);
        PlantPanel.SetActive(false);
        OpenButton.SetActive(true);
    }

    public void SelectStructure(int index)
    {
        placement_sys.ID_index = index;
    }

    public void SelectPlant(int index)
    {
        placement_sys.PLANT_ID_index = index;
    }

    public void OpenBuildPanel()
    {
        BuildPanel.SetActive(true);
        PlantPanel.SetActive(false);
        placement_sys.PlantMode = false;
    }

    public void OpenPlantPanel()
    {
        BuildPanel.SetActive(false);
        PlantPanel.SetActive(true);
        placement_sys.PlantMode = true;
    }
}
