using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantDB")]
public class PlantDB : ScriptableObject
{
    [SerializeField]
    public List<Structure> container = new List<Structure>();
}

[System.Serializable]
public class Plant
{
    public string NAME;
    public string ID;
    public GameObject PREFAB;
}
