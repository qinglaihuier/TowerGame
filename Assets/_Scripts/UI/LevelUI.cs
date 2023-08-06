using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("bg/forest").GetComponent<Button>().onClick.AddListener(OpenForestLevel);
        transform.Find("bg/snow").GetComponent<Button>().onClick.AddListener(OpenSnowLevel);
        transform.Find("bg/castle").GetComponent<Button>().onClick.AddListener(OpenCastleLevel);
    }

    // Update is called once per frame
    void OpenForestLevel()
    {
        UIManager.Instance.ShowUI<LoadingUI>("LoadingUI").LoadScene("forest");
    }
    void OpenSnowLevel()
    {

    }
    void OpenCastleLevel()
    {

    }
}
