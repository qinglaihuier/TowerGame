using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Move(List<Vector3> targetPositions)
    {
        StartCoroutine(nameof(MoveCor),targetPositions);
    }

    public void GetHit()
    {
        anim.Play("Die");

        StopAllCoroutines();

        Destroy(gameObject, 1);
    }
    IEnumerator MoveCor(List<Vector3> targetPositions)
    {
        int index = 0;
        Vector3 target = targetPositions[index];
        transform.LookAt(target);
        target.y = 1;
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 2.3f);
            
            if (Vector3.Distance(transform.position, target) < 0.02f)
            {
                transform.position = target;
                index++;

                if(index>targetPositions.Count - 1)
                {
                    break;
                }
                else
                {
                    target = targetPositions[index];
                    target.y = 1;
                    transform.LookAt(target);
                }
            }
            yield return null;
        }

        Destroy(gameObject);
    }
    // Update is called once per frame

}
