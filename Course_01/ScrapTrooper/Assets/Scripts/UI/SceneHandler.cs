using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("Scraptrooper");
    }
    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnControllsButtonPressed()
    {
        SceneManager.LoadScene("Controlls");
    }

}
