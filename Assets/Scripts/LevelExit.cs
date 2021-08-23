using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    Collider2D myCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        myCollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myCollider2D.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            StartCoroutine("NextLevel");
        }
    }

    IEnumerator NextLevel()
    {
        Time.timeScale = 0.25f;
        yield return new WaitForSeconds(1f);
        Destroy(FindObjectOfType<LevelPersistence>().gameObject);

        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
