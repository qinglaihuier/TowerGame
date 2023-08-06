using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    GameObject leftItemObj;
    GameObject startBtnObj;
    GameObject pauseBtnObj;
    Transform contentTf;
    GameObject itemObj;
    // Start is called before the first frame update
    void Start()
    {
        leftItemObj = transform.Find("leftImg").gameObject;
        startBtnObj = transform.Find("startBtn").gameObject;
        pauseBtnObj = transform.Find("pauseBtn").gameObject;
        contentTf = transform.Find("content");
        itemObj = transform.Find("content/Item").gameObject;

        transform.Find("returnBtn").GetComponent<Button>().onClick.AddListener(OnReturnBtn);
        startBtnObj.GetComponent<Button>().onClick.AddListener(GameStart);
    }

    void GameStart()
    {
        EnemyManager.Instance.BeginCreateEnemy();
        
    }
    private void OnReturnBtn()
    {
        UIManager.Instance.ShowUI<LoadingUI>("LoadingUI").LoadScene("login");
    }

    public void AddTowerItem(TowerData data)
    {
        GameObject obj = Instantiate(itemObj, contentTf);
        obj.transform.Find("icon").GetComponent<Image>().sprite = Resources.Load<Sprite>(data.Icon);
        obj.AddComponent<UseTrapItem>().data = data;
        obj.name = data.Name;
        obj.SetActive(true);
    }
    public void RemoveTowerItem(TowerData data)
    {
        for(int i = 0; i < contentTf.childCount; ++i)
        {
            if(data.Name == contentTf.GetChild(i).name)
            {
                Destroy(contentTf.GetChild(i).gameObject);
                break;
            }
        }
    }
    public void OpenOtherGameUI()
    {
        itemObj.SetActive(true);
        startBtnObj.SetActive(true);
        pauseBtnObj.SetActive(true);
    }
    // Update is called once per frame
   
}
