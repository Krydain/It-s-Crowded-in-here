using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public Button playButton;
    public Button exitButton;
    
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(ClickOnPlay);
        exitButton.onClick.AddListener(ClickOnExit);
    }

    private void ClickOnPlay()
    {
        PlayerPrefs.SetInt("floor", 0);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    
    private void ClickOnExit()
    {
        Application.Quit();
    }
}
