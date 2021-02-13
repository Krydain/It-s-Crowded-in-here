using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Text textLevel;
    public Text textFloor;
    
    // Start is called before the first frame update
    void Start()
    {
        textLevel.text = SceneManager.GetActiveScene().name;
        textFloor.text = "Etage : " + PlayerPrefs.GetInt("floor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
