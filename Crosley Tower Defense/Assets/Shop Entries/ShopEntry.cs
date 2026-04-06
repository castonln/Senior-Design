using System;
using UnityEngine;
[Serializable]
public class UpgradePath
{
    public string pathTitle;
    public string pathDescription;
    public int pathCost;
    public GameObject pathPrefab;

    public UpgradePath(string pathTitle, string pathDescription, int pathCost, GameObject pathPrefab)
    {
        this.pathTitle = pathTitle;
        this.pathDescription = pathDescription;
        this.pathCost = pathCost;
        this.pathPrefab = pathPrefab;
    }
}

[CreateAssetMenu(fileName = "ShopEntry", menuName = "Shop Entries/ShopEntry")]
[Serializable]
public class ShopEntry: ScriptableObject
{
    public string name;
    public string description;
    public int cost;
    public GameObject prefab;
    public UpgradePath path1;
    public UpgradePath path2;

    public ShopEntry(string _name, string _description, int _cost, GameObject _prefab)
    {
        name = _name; 
        description = _description;
        cost = _cost; 
        prefab = _prefab;
    }

    public ShopEntry(string _name, string _description, int _cost, GameObject _prefab, UpgradePath _path1, UpgradePath _path2)
    {
        name = _name;
        description= _description;
        cost = _cost;
        prefab = _prefab;
        path1 = _path1;
        path2 = _path2;
    }
}

[CreateAssetMenu(fileName = "ShopEntries", menuName = "Shop Entries/ShopEntries")]
public class ShopEntries : ScriptableObject
{
    public ShopEntry[] shopEntries;
}