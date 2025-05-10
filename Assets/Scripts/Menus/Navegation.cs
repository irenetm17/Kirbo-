using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegation : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
