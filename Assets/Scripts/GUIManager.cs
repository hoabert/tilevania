using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    GameSession myGameSession;

    // Start is called before the first frame update
    void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        if (myGameSession)
        {
            myGameSession.UpdateHud();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
