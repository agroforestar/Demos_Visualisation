using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

     public void Quit()
    {
        Application.Quit();
    }



    public static int nextSceneIndex = 0; // Index de la prochaine scène à charger après "Questions"
    public void LoadNextScene()
    {
        Tractors.TractorInitialisation = false;
        Tractors2.TractorInitialisation = false;
        nextSceneIndex++;
        SceneManager.LoadScene("Visu" + nextSceneIndex);
        
    }

    public void LoadPreviousScene()
    {
        Tractors.TractorInitialisation = false;
        Tractors2.TractorInitialisation = false;
        nextSceneIndex--;
        SceneManager.LoadScene("Visu" + nextSceneIndex);
        
    }





}
