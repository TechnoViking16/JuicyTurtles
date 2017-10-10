using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    
    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }
    public void ExitGameBtn()
    {
        Debug.Log("Exitsgame");
        Application.Quit(); 
    }
}
