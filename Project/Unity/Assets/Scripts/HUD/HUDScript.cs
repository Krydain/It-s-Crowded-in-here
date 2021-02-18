﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Text textLevel;
    public Text textFloor;
    public Text textObjectif;
    public Canvas inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        textLevel.text = SceneManager.GetActiveScene().name;
        textFloor.text = "Etage : " + PlayerPrefs.GetInt("floor");
        textObjectif.text = "Objectif : Trouver la carte de l'ascenceur";
        inventory.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.gameObject.SetActive(true);
        }
        
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            inventory.gameObject.SetActive(false);
        }
    }
}
