using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void Start()
    {
        LoadNextScene();
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(1);
    }
}
