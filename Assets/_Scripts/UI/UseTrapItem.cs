using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class UseTrapItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public TowerData data;

    GameObject IconModel;
    public void OnBeginDrag(PointerEventData eventData)
    {
       IconModel = UIManager.Instance.CreateIcon(data);

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(IconModel.transform.parent.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out pos))
        {
            IconModel.GetComponent<RectTransform>().anchoredPosition = pos;
        }
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UIManager.Instance.Close(data.Name);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            if(hit.transform.gameObject.tag == "Empty")
            {
                GameObject modelObj = Instantiate(Resources.Load(data.Model)) as GameObject;
                Vector3 pos = hit.transform.position;
                pos.y = 1;
                modelObj.transform.position = pos;
               TrapBase trap = modelObj.AddComponent(System.Type.GetType(data.Type)) as TrapBase;
                trap.SetBlock(hit.transform.gameObject, data);
            }
        }
      
    }

    
    // Start is called before the first frame update
    
}
