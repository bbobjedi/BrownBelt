using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    public ParticleSystem explosion;

    public ParticleSystem trail;

    public GameObject player;

    public GameObject gameoverbackground;
    
    void Start()
    {
        explosion.Stop();
        gameoverbackground.SetActive(false);
    }

    void Update()
    {
        trail.transform.position = player.transform.position;
    }


    void FixedUpdate()
    {
        explosion.transform.position = player.transform.position;
    }

     public void GameOver()
    {
        player.SetActive(false);
        Invoke("Reload", 1);
        explosion.Play();
    }

    void Reload()
    {
        SceneManager.LoadScene(0);
        gameoverbackground.SetActive(true);
    }
}


