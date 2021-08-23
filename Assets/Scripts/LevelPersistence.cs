using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPersistence : MonoBehaviour
{
    void Awake()
    {
        int numberofScenePersistence = FindObjectsOfType<LevelPersistence>().Length;

        if (numberofScenePersistence > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

}
