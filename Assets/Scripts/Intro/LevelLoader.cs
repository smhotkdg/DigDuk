using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject LoadingScreen;
    //public Slider slider;
    public Text progrssText;
    public GameObject TouchText;

    bool start = false;
    private void Awake()
    {
        
    }
    public void LoadLevel(string nameScene)
    {
        if(start == false)
        {
            LoadingScreen.SetActive(true);
            TouchText.SetActive(false);

            StartCoroutine(LoadAsynchronously(nameScene));
            start = true;            
        }
    }
  

    IEnumerator LoadAsynchronously(string nameScen)
    {
        yield return new WaitForSeconds(0.1f);
        AsyncOperation opertation = SceneManager.LoadSceneAsync(nameScen);
        //AsyncOperation opertation =  Application.LoadLevelAsync(0);
        
        while (!opertation.isDone)
        {
            float progress = Mathf.Clamp01(opertation.progress / .9f);
            
            if(progress * 100f > 100)
            {
                progrssText.text = 100.ToString("N2") + "%";
            }
            else
            {
                float temp = progress * 100f;
                progrssText.text =  temp.ToString("N2") + "%";
                
            }            
            yield return null;
        }
    }

    float GetResolution(int width, int height)
    {
        float scRatio = (float)width / (float)height;
        float scRound = Mathf.Round(scRatio * 100.0f);
        scRound = scRound / 100f;
        return scRound;
    }
}
