using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectUI : MonoBehaviour
{
    Transform left;
    Transform right;
    GameObject itemObjPrefab;
        
    // Start is called before the first frame update
    void Start()
    {
        left = transform.Find("bg/left");
        right = transform.Find("bg/right");
        itemObjPrefab = transform.Find("bg/left/item").gameObject;
        transform.Find("bg/startBtn").GetComponent<Button>().onClick.AddListener(OnStartGameBtn);

        TowerData[] list= ConfigManager.Instance.towerDatas.Data;

        for (int i = 0; i < list.Length; ++i)
        {
           GameObject obj = Instantiate(itemObjPrefab, left);

            obj.AddComponent<TrapItem>().data = list[i];
            obj.transform.localScale = Vector3.one;
            obj.SetActive(true);
        }
    }

    void OnStartGameBtn()
    {
        UIManager.Instance.Close("SelectUI");
        UIManager.Instance.GetUI<GameUI>("GameUI").OpenOtherGameUI();
    }

    public void RefreshItemMsg(TowerData data)
    {
        right.Find("icon").GetComponent<Image>().sprite = Resources.Load<Sprite>(data.Icon);

        string msg = "Ãû×Ö: " + data.Name + "\n" + "¹¥»÷Á¦: " + data.Attack + "\n" + "ÑªÁ¿£º" + data.Hp;

        right.Find("Text").GetComponent<Text>().text = msg;
    }
    // Update is called once per frame
   
}
