using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegation : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Juego1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
