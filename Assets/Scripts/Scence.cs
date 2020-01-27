using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scence : MonoBehaviour
{
    public void ScenceLoad()
    {
        SceneManager.LoadScene("Game");
    }
    public void GameEnd()
    {
        Application.Quit();
    }
}
