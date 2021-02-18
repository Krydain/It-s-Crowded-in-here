using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Trigger
{
    public class TriggerNextLevel : MonoBehaviour
    {
        public GameObject playerBody;
        public GameObject player;
        private PlayerInventory pi;
        public Canvas hud;
        private GameObject needKeyGO;

        // Start is called before the first frame update
        void Start()
        {
            pi = player.GetComponent<PlayerInventory>();
            needKeyGO = new GameObject("myTextGO");
            needKeyGO.transform.SetParent(hud.gameObject.transform);

            RectTransform needKeyRect = needKeyGO.AddComponent<RectTransform>();
            needKeyRect.anchoredPosition= Vector2.zero;
            needKeyRect.sizeDelta = new Vector2(400,30);
            
            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            Text needKeyText = needKeyGO.AddComponent<Text>();
            needKeyText.text = "Vous avez besoin d'une clé pour passer a l'étage suivant";
            needKeyText.font = ArialFont;
            
            needKeyGO.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.Equals(playerBody))
            {
                if (pi.GetNbKey() > 0)
                {
                    int floor = PlayerPrefs.GetInt("floor");
                    floor++;
                    PlayerPrefs.SetInt("floor", floor);
                    int nextFloor = floor + 2;
                    if (nextFloor >= SceneManager.sceneCountInBuildSettings)
                    {
                        SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
                    }
                    else
                    {
                        SceneManager.LoadScene(nextFloor, LoadSceneMode.Single);
                    }
                }
                else
                {
                    Debug.Log("Pas de clé");
                    needKeyGO.SetActive(true);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            
            needKeyGO.SetActive(false);
                
        }
    }
}
