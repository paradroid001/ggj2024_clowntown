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
        int levelStartTime = 120;
        private float levelTime = 0;
        [SerializeField]
        int levelEnrageThreshold = 60; //how many seconds left when enrage mode entered.

        [SerializeField]
        protected BossEnemy boss;

        [SerializeField]
        Transform[] playerSpawns = new Transform[4]; //TODO hardcoded :X

        protected int currentPlayersInLevel = 0;

        protected LevelUI levelUI;

        // Start is called before the first frame update
        void Start()
        {
            levelUI = ClownGameManager.GetInstance().GetLevelUI();
            levelTime = levelStartTime;
            levelUI.SetTime((int)levelTime);
            ClownGameManager.GetInstance().SetCurrentLevelManager(this);
        }

        // Update is called once per frame
        void Update()
        {
            levelTime -= Time.deltaTime;
            levelUI.SetTime((int)levelTime);
        }

        void DisplayLevelName()
        {
            ClownGameManager.GetInstance().OnDisplayLevelName(levelName);
        }

        public BossEnemy GetBoss()
        {
            return boss;
        }



        public void OnPlayerJoin(PlayerInput playerInput)
        {
            Debug.Log("On Player Join");
            currentPlayersInLevel += 1;
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
            currentPlayersInLevel -= 1;
        }


    }
}