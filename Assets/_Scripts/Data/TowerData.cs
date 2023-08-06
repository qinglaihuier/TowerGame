using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TowerDataList
{
    public TowerData[] Data;
}
[System.Serializable]
public class TowerData 
{
    public string Id;
    public string Name;
    public int Attack;
    public int Hp;
    public int Money;
    public string Icon;
    public string Model;
    public string Type;
    
}
