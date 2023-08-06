using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager Instance;

    Dictionary<string, GameObject> uiDic = new Dictionary<string, GameObject>();

    private void Awake()
    {
        Instance = this;
    }
    public T ShowUI<T>(string uiName) where T : Component
    {
        if (uiDic.ContainsKey(uiName))
        {
            uiDic[uiName].SetActive(true);
        }
        else
        {
            GameObject newUI = Instantiate(Resources.Load("UI/" + uiName), transform) as GameObject;
            newUI.AddComponent<T>();
            newUI.gameObject.name = uiName;
            uiDic.Add(uiName, newUI);
        }

        return uiDic[uiName].GetComponent<T>();
    }
    public void Close(string uiName)
    {
        if (uiDic.ContainsKey(uiName))
        {
            Destroy(uiDic[uiName]);
            uiDic.Remove(uiName);
        }
    }

    public void CloseAll()
    {
        foreach(var ui in uiDic)
        {
            Destroy(ui.Value);
        }
        uiDic.Clear();
    }

    public T GetUI<T>(string uiName) where T : Component
    {
        if (uiDic.ContainsKey(uiName))
        {
            return uiDic[uiName].GetComponent<T>();
        }
        return null;
    }
    public GameObject CreateIcon(TowerData data)
    {
        GameObject obj = new GameObject(data.Name);
        uiDic.Add(data.Name, obj);
        obj.transform.parent = transform;
        obj.AddComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(data.Icon);

        return obj;
    }
}
