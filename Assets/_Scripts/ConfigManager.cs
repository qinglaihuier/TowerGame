using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance;

    public TowerDataList towerDatas;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        towerDatas = new TowerDataList();
    }
    // Update is called once per frame
    private void Start()
    {
        TextAsset towerTextAsset = Resources.Load<TextAsset>("Data/Tower");

        string jsonStr = towerTextAsset.text;

        towerDatas = JsonUtility.FromJson<TowerDataList>(jsonStr);

    }
    public TowerData GetTowerDataById(string id)
    {
        for(int i = 0; i < towerDatas.Data.Length; ++i)
        {
            if(towerDatas.Data[i].Id == id)
            {
                return towerDatas.Data[i];
            }
        }
        return null;
    }
}
