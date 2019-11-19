using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public AudioClip clip;
    public GameObject particleAnimation;
    
    public Sprite[] sprites;
    
    private Gameplay gameplay;
    private GameStatus gameStatus;
    private int hitCount;
    private int maxHits;
    
    private void Start()
    {
        maxHits = sprites.Length;
        gameplay = FindObjectOfType<Gameplay>();
        if(gameObject.tag == "Breakable")
            gameplay.IncreaseBoxCount();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        if (gameObject.tag == "Breakable")
        {
            hitCount++;
            if (hitCount >= maxHits)
            {
                DestroyBlock();
            }else
            {
                ShowNextSprite();
            }
        }
    }

    private void ShowNextSprite()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[hitCount - 1];
    }

    private void TriggerParticleAnimation()
    {
        GameObject anim = Instantiate(this.particleAnimation, transform.position, transform.rotation);
        Destroy(anim, 1f);
    }

    private void DestroyBlock()
    {
        
        Destroy(gameObject);
        gameplay.DecreaseBoxCount();
        gameStatus.IncreaseScore();
        TriggerParticleAnimation();
    }
}
