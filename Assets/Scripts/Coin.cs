using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
	protected ParticleSystem m_ParticleSystem;
    [SerializeField]
    protected SpriteRenderer m_SpriteRenderer;
    [SerializeField]
    protected Collider2D m_Collider2D;
    [SerializeField]
    protected AudioSource m_audiosource;

    void OnCollisionEnter2D (Collision2D col){
        if (col.gameObject.tag.Equals ("Player")){
            print("Coin");
            if(m_ParticleSystem.isPlaying) m_ParticleSystem.Stop();
            m_ParticleSystem.Play();
            m_audiosource.Play();
            m_SpriteRenderer.enabled = false;
			m_Collider2D.enabled = false;
           
            Destroy(gameObject, m_ParticleSystem.main.duration); 
            CoinCounter.coincount += 1;
        }
    }
}
