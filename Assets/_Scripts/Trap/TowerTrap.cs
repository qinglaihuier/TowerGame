using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TowerTrap : TrapBase
{
    Transform point;
    // Start is called before the first frame update
    void Start()
    {
        point = transform.Find("point");

        InvokeRepeating("CreateBullet", 3, 3);
    }

    void CreateBullet()
    {
        Debug.Log("Create Bullet");
        GameObject bullet = Instantiate(Resources.Load("Model/bullet")) as GameObject;
        bullet.transform.position = point.position;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 5, ForceMode.Impulse);
        bullet.AddComponent<Bullet>();

        Debug.Log(bullet.transform.position);
    }
   

    // Update is called once per frame

}
