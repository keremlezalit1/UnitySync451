using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingDB")]
public class BuildingDB : ScriptableObject
{
    //Kadirhan Scriptable Object Unityde Database olarak kullan�l�r Bu db'de yap�lacak de�i�iklikler oyunu kapat�p a�san bile kal�r kal�c�d�r
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
