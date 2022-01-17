using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator anim;
    [SerializeField]
	protected ParticleSystem m_ParticleSystem;
    [SerializeField]
    protected SpriteRenderer m_SpriteRenderer;
    [SerializeField]
    protected Sprite m_Sprite;
    [SerializeField]
    protected Collider2D m_Collider2D;
    [SerializeField]
    protected AudioSource m_audiosource;
    [SerializeField]
    protected GameObject m_chestOpen;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D (Collision2D col){
        if (col.gameObject.tag.Equals ("Player")){
            print("Chest");

            if(m_ParticleSystem.isPlaying) m_ParticleSystem.Stop();
            m_ParticleSystem.Play(); 
            anim.SetTrigger("Open");
            m_audiosource.Play();

            m_SpriteRenderer.enabled = false;
			m_Collider2D.enabled = false;
           
            Destroy(gameObject, m_ParticleSystem.main.duration); 
            m_chestOpen.SetActive(true);
            CoinCounter.coincount += 10;
        }
    }
}
