using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    static GameManager _instance = null;
    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }


    int _score = 0;
    int _lives = 1;
    public int maxLives = 3;
    public GameObject playerPrefab;

    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            onScoreValueChange.Invoke(value);
            Debug.Log("Score Set To: " + score.ToString());
        }
    }

    public int lives
    {
        get { return _lives; }
        set
        {
            if (_lives > value)
            {
                //respawn our character at checkpoint
                Destroy(playerInstance);
                SpawnPlayer(currentLevel.spawnPoint);
            }


            _lives = value;
            if (_lives > maxLives)
                _lives = maxLives;

            onLifeValueChange.Invoke(value);

            if (_lives < 0)
            {
                SceneManager.LoadScene("GameOver");


            }

            Debug.Log("Lives Set To: " + lives.ToString());
        }
    }

    [HideInInspector] public UnityEvent <int> onLifeValueChange;
    [HideInInspector] public UnityEvent <int> onScoreValueChange;

    [HideInInspector] public GameObject playerInstance;
    [HideInInspector] public Level currentLevel;


    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Backspace))
        //{
        //    if (SceneManager.GetActiveScene().name == "MainMenu")
        //        SceneManager.LoadScene("Level");
        //    else
        //        SceneManager.LoadScene("MainMenu");
        //}

        if (Input.GetKeyDown(KeyCode.UpArrow))
            lives--;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "GameOver")
                SceneManager.LoadScene("MainMenu");
        }
        {
        //#if UNITY_EDITOR
        //    UnityEditor.EditorApplication.isPlaying = false;
        //#else
        //    Application.Quit();
        //#endif
        }
    }

    public void SpawnPlayer(Transform spawnLocation)
    {
        playerInstance = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
    }
}
