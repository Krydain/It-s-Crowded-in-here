using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GetElevatorCard : MonoBehaviour
{
    public Text objectif;
    public Text nbKey;
    public GameObject playerBody;
    public GameObject player;
    public GameObject card;
    private PlayerInventory pi;

    private void Start()
    { 
        pi = player.GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerBody)
        {
            pi.PlayerGetKey();
            objectif.color = Color.yellow;
            nbKey.text = "Nombre de clé en possession : 1";
            Destroy(card);
        }
    }
}
