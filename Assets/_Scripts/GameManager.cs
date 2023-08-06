using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        GameObject.Find("Canvas").AddComponent<UIManager>();

        UIManager.Instance.ShowUI<LoadingUI>("LoadingUI").LoadScene("login");
    }

    // Update is called once per frame
   
}
