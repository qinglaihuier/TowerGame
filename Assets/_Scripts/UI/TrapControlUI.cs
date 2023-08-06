using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrapControlUI : MonoBehaviour
{
    TrapBase trap;
    Transform content;
    // Start is called before the first frame update
    void Start()
    {
        content = transform.Find("content");
        transform.Find("content/deModelBtn").GetComponent<Button>().onClick.AddListener(OnDeleteModelBtn);
        transform.Find("content/rotateBtn").GetComponent<Button>().onClick.AddListener(OnRotateBtn);
        transform.Find("content/closeBtn").GetComponent<Button>().onClick.AddListener(OnCloseBtn);
    }

    void OnCloseBtn()
    {
        UIManager.Instance.Close(gameObject.name);
    }

    void OnDeleteModelBtn()
    {
        Destroy(trap.gameObject);
        UIManager.Instance.Close(gameObject.name);
    }

    void OnRotateBtn()
    {
        Vector3 angel = trap.gameObject.transform.eulerAngles;
        angel.y += 90;
        trap.gameObject.transform.eulerAngles = angel;
    }

    private void LateUpdate()
    {
        if (trap != null)
        {
            content.position = Vector3.Lerp(content.position, Camera.main.WorldToScreenPoint(trap.transform.position), Time.deltaTime * 5f);
        }
    }

    public void SetTrap(TrapBase trap)
    {
        this.trap = trap;
        
    }
    // Update is called once per frame
    
}
