using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private int nbKey;
    // Start is called before the first frame update
    void Start()
    {
        nbKey = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerGetKey()
    {
        nbKey++;
        Debug.Log("Clé ajouté à l'inventaire");
    }

    public int GetNbKey()
    {
        return nbKey;
    }
}
