using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNextLevel : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        Debug.Log(other.gameObject);
        if (other.gameObject.Equals(player))
        {
            int floor = PlayerPrefs.GetInt("floor");
            floor++;
            PlayerPrefs.SetInt("floor", floor);
            int nextFloor = floor + 2;
            if (nextFloor > SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene(nextFloor, LoadSceneMode.Single);
            }
        }
    }
}
