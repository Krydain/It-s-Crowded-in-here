using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CivilianController : MonoBehaviour
{
    public int walkRadius;
    public NavMeshAgent civilianAgent;
    private Vector3 lastPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPosition == civilianAgent.transform.position)
        {
            Walk();
        }

        lastPosition = civilianAgent.transform.position;
    }

    void Walk()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        Vector3 finalPosition = hit.position;

        FaceTarget(finalPosition);
        civilianAgent.SetDestination(finalPosition);
    }
    
    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.1f);  
    }
}
