using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TrapItem : MonoBehaviour,IPointerClickHandler
{
    // Start is called before the first frame update
    public TowerData data;

    private void Start()
    {
        transform.Find("icon").GetComponent<Image>().sprite = Resources.Load<Sprite>(data.Icon);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        bool isActive = transform.Find("mark").gameObject.activeSelf;
        transform.Find("mark").gameObject.SetActive(!isActive);

        UIManager.Instance.GetUI<SelectUI>("SelectUI").RefreshItemMsg(data);

        if (!isActive)
        {
            UIManager.Instance.GetUI<GameUI>("GameUI").AddTowerItem(data);
        }
        else
        {
            UIManager.Instance.GetUI<GameUI>("GameUI").RemoveTowerItem(data);
        }
    
    }
}
