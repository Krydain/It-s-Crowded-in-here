using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameplayManager : MonoBehaviour
{
    public int nbCivilian;
    public int area;
    public GameObject civilianPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < nbCivilian; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * area;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, area, 1);
            Vector3 finalPosition = hit.position;
            
            Instantiate(civilianPrefab,finalPosition, Quaternion.Euler(0, 0,0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
