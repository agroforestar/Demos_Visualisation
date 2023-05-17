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

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }


     public void Quit()
    {
        Application.Quit();
    }





}
