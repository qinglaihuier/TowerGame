using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("bg/startGameBtn").GetComponent<Button>().onClick.AddListener(OnStartGameBtn);
        transform.Find("bg/setBtn").GetComponent<Button>().onClick.AddListener(OnSetBtn);
        transform.Find("bg/quitBtn").GetComponent<Button>().onClick.AddListener(OnQuitBtn);
    }

    // Update is called once per frame
    void OnStartGameBtn()
    {
        UIManager.Instance.ShowUI<LevelUI>("LevelUI");
    }
    void OnSetBtn()
    {
        Debug.Log("Set");
    }
    void OnQuitBtn()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
}
