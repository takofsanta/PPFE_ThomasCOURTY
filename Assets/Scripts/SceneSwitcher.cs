using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{


    public AudioClip tic;
    public AudioSource audioSource;
    SoupBehavior soupbehavior;
    public void Jouer()
    {
        SceneManager.LoadScene(1);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);

    }

    public void Next()
    {
        SceneManager.LoadScene(2);
    }

    public void clicSound()
    {
        audioSource.clip = tic;
        audioSource.Play();
    }
}
