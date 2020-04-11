using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject player;

    public void Start()
    {
        Invoke("LoadNextScene", 0.35f);
        enableExplosion();
    }

    private void enableExplosion() {
        //player.GetComponent<SphereExploder>().enabled = true;
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(1);
    }
}
