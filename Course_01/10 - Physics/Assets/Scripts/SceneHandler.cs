using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("PrisonBasketBall");
    }

    public void OnPrisonButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnMeatButtonPressed()
    {
        SceneManager.LoadScene("Meatship");
    }
}
