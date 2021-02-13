using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenuScript : MonoBehaviour
{
    public Button returnToMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        returnToMenuButton.onClick.AddListener(ClickOnRTM);
    }

    private void ClickOnRTM()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
