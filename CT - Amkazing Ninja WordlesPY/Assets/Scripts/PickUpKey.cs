using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    SpriteRenderer m_renderer;
    public ParticleSystem m_particle;

    public ParticleSystem allParticles;

    public GameObject HealthBar;

    public GameObject player;


    private void Start()
    {
        m_renderer = GetComponentInParent<SpriteRenderer>();
    }

    public void OnTriggerEnter(Collider other)
    {
            HealthBar.GetComponent<LifeHUD>().HealPlayer();
            m_renderer.enabled = false;
            m_particle.Stop();
            allParticles.Play();
            
    }

}
