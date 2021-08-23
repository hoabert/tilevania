using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int lives = 5;
    [SerializeField] int score = 0;


    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text scoreText;

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
        UpdateHud();
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void UpdateHud()
    {
        livesText.text = lives.ToString();
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
        UpdateHud();
        SceneManager.LoadScene(currentScene);
    }

    void ResetGameSession()
    {
        Destroy(FindObjectOfType<LevelPersistence>().gameObject);
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
}
