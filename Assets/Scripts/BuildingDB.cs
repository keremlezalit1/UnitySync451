using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingDB")]
public class BuildingDB : ScriptableObject
{
    //Kadirhan Scriptable Object Unityde Database olarak kullanýlýr Bu db'de yapýlacak deðiþiklikler oyunu kapatýp açsan bile kalýr kalýcýdýr
    [SerializeField]
    public List<Structure> container = new List<Structure>();

}


[System.Serializable]
public class Structure
{
    public string NAME;
    public string ID;
    public GameObject PREFAB;
}
