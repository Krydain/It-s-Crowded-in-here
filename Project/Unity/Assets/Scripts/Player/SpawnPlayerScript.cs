using UnityEngine;

namespace Player
{
    public class SpawnPlayerScript : MonoBehaviour
    {
        [SerializeField]
        private GameObject playerPrefab;

        [SerializeField] private Transform playerSpawnTransform;
    
        // Start is called before the first frame update
        void Start()
        {
            Instantiate(playerPrefab, playerSpawnTransform);
        }
        
    }
}
