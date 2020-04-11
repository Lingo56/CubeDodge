using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelComplete : MonoBehaviour
{
    public void LoadNextLevel() {
        SceneManager.LoadScene(0);
    }
}
