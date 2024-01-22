using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ClownTown
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        string levelName = "Unknown Level";
        [SerializeField]
        Transform[] playerSpawns = new Transform[4]; //TODO hardcoded :X
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void DisplayLevelName()
        {
            ClownGameManager.GetInstance().OnDisplayLevelName(levelName);
        }

        public void OnPlayerJoin(PlayerInput playerInput)
        {
            Debug.Log("On Player Join");
            PlayerManager p = playerInput.gameObject.GetComponent<PlayerManager>();
            if (p != null)
            {
                p.transform.position = playerSpawns[playerInput.playerIndex].position;
                p.PlayerSetup(playerInput.playerIndex);
            }
            else
            {
                Debug.LogWarning("Joining player did not have a PlayerManager");
            }
        }
        public void OnPlayerLeave(PlayerInput playerInput)
        {

        }
    }
}