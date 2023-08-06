using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager 
{
    float createEnemyInternal = 3f;

    private static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EnemyManager();
            }
            return instance;
        }
    }
    public void BeginCreateEnemy()
    {
        UIManager.Instance.StartCoroutine(CreateEnemys());
    }
    IEnumerator CreateEnemys()
    {
        WaitForSeconds wait = new WaitForSeconds(createEnemyInternal);
        for(int i = 0; i < 10; ++i)
        {
            Transform beginPoint = GetRandomTf();

            GameObject enemy = Object.Instantiate(Resources.Load("Model/Slime")) as GameObject;
            enemy.transform.position = beginPoint.position;

            List<Vector3> path = new List<Vector3>();

            for(int m = 0; m < beginPoint.childCount; ++m)
            {
                var point = beginPoint.GetChild(m).position;
                path.Add(point);
            }

            enemy.AddComponent<Enemy>().Move(path);
            yield return wait;
        }
       
    }

    Transform GetRandomTf()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");

        return points[Random.Range(0, points.Length)].transform;
    }
    // Start is called before the first frame update
    
}
