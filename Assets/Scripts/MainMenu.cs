using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LeaveGame()
    {
        Application.Quit();
        Debug.Log("Leaving the game");
    }

    public void Credits()
    {

    }
}
