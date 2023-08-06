using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingUI : MonoBehaviour
{
    Text loadingTxt;
    Slider loadingSlider;

    float loadingProgess = 0;

    AsyncOperation asyOp =new AsyncOperation() ;
    public void LoadScene(string sceneName)
    {
        loadingTxt = transform.Find("bg/loadingTxt").GetComponent<Text>();
        loadingSlider = transform.Find("bg/slider").GetComponent<Slider>();

        loadingTxt.text = "加载中... 0";
        loadingSlider.value = 0;

        asyOp = SceneManager.LoadSceneAsync(sceneName);

        asyOp.allowSceneActivation = false;

        asyOp.completed += AsyOp_completed;

       
    }

    private void AsyOp_completed(AsyncOperation obj)
    {
        UIManager.Instance.CloseAll();
        string activeSceneName = SceneManager.GetActiveScene().name;
        if (activeSceneName == "login")
        {
            UIManager.Instance.ShowUI<LoginUI>("LoginUI");
        }
        else
        {
            UIManager.Instance.ShowUI<GameUI>("GameUI");
            UIManager.Instance.ShowUI<SelectUI>("SelectUI");
        }
    }

    void Update()
    {
        loadingProgess = asyOp.progress;

        if (loadingProgess >= 0.9f)
        {
            loadingProgess = 1;
           
        }

        loadingSlider.value = Mathf.Lerp(loadingSlider.value, loadingProgess, Time.deltaTime * 7);
        loadingTxt.text = "加载中... " + (loadingSlider.value* 100).ToString("0.0") + "%";

        if(loadingSlider.value >= 0.98f)
        {
            asyOp.allowSceneActivation = true;
           
        }

    }
}
