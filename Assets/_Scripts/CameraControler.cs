using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CameraControler : MonoBehaviour
{
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        MoveHV();
        MoveForward();
        Rotate();
    }
    public void MoveHV()
    {
        if (Input.GetMouseButton(2))
        {
            if(EventSystem.current.IsPointerOverGameObject() == true)
            {
                return;
            }
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            if (x != 0 || y != 0)
            {
                transform.position = transform.position + transform.right * x + transform.up * y;
            }
        }
        
    }
    public void MoveForward()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            transform.position = transform.position + transform.forward * scroll * 3;
        }

    }
    Vector3 targetPos;  //Î§ÈÆµÄÐý×ªµã
    public void Rotate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                targetPos = hit.transform.position;
            }
            else
            {
                targetPos = transform.position + transform.forward * 10;
            }
           
        }
        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X");
            transform.RotateAround(targetPos, Vector3.up, x * 3);
        }
       

    }
}
