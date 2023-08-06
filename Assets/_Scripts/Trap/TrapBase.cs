using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TrapBase : MonoBehaviour
{
    GameObject blockObj;
    TowerData data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetBlock(GameObject blockObj,TowerData data)
    {
        this.blockObj = blockObj;
        this.data = data;
        blockObj.tag = "Untagged";
    }
    private void OnDestroy()
    {
        if (blockObj == null)
        {
            return;
        }
        blockObj.tag = "Empty";
    }
    private void OnMouseDown()
    {
        Debug.Log("TowerTrao OnMouseDown");
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        UIManager.Instance.ShowUI<TrapControlUI>("TrapControllerUI").SetTrap(this);
    }
}
