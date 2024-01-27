using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClownTown
{
    public class ClownGameManager : MonoBehaviour
    {
        protected static ClownGameManager instance = null;
        public string gameSceneName;
        public string menuSceneName;

        [SerializeField]
        protected LevelUI levelUI;
        
        public GameObject mainMenu;
        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                Init();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static ClownGameManager GetInstance()
        {
            return instance;
        }

        public LevelUI GetLevelUI()
        {
            return levelUI;
        }

        void Init()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDisable()
        {
            Debug.Log("ClownGameManager disabled");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == gameSceneName)
            {
                OnGameSceneEnter();
            }
            else if (scene.name == menuSceneName)
            {
                OnMenuSceneEnter();
            }
        }

        void OnMenuSceneEnter()
        {
            mainMenu.SetActive(true);
        }

        void OnGameSceneEnter()
        {
            mainMenu.SetActive(false);
        }

        public void OnPlay()
        {
            Debug.Log("OnPlay");
            SceneManager.LoadScene(gameSceneName);
        }
        public void OnCredits()
        {
            Debug.Log("OnCredits");
        }
        public void OnQuit()
        {
            Application.Quit();
        }

        public void OnDisplayLevelName(string levelName)
        {
            Debug.Log($"Display Level Name: {levelName}");
        }
        
    }
}
