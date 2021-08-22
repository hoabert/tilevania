using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int lives = 5;

    private void Awake()
    {
        int numberOfSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfSessions > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDeathHandler()
    {
        if (lives > 0)
        {
            LivesHandler();
        }
        else
        {
            ResetGameSession();
        }
    }

    void LivesHandler()
    {
        lives--;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void ResetGameSession()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
}
