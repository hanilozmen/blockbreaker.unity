using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Box : MonoBehaviour
{
    public AudioClip clip;
    public GameObject particleAnimation;
    

    public Sprite[] sprites;


    private int hitCount;
    private int maxHits;
    private List<Box> sameColumnBoxes;
    private int charStartPosX;
    private int boxHolderTopPosY;
    
    private Char character;
    private Gameplay gameplay;
    private GameStatus gameStatus;
    private BoxHolder boxHolder;

    private void Awake()
    {
        character = FindObjectOfType<Char>();
        gameplay = FindObjectOfType<Gameplay>();
        gameStatus = FindObjectOfType<GameStatus>();
        boxHolder = FindObjectOfType<BoxHolder>();
    }

    private void Start()
    {
        charStartPosX = Convert.ToInt32(character.transform.position.x);
        boxHolderTopPosY = Convert.ToInt32(boxHolder.GetComponent<Collider2D>().bounds.max.y); 
        sameColumnBoxes = new List<Box>();
        maxHits = sprites.Length;
        if (gameObject.tag == "Breakable")
            gameplay.IncreaseBoxCount();
    }

    private void FindSameColumnBoxes()
    {
        sameColumnBoxes.Clear();
        foreach (var item in FindObjectsOfType<Box>())
        {
            if (item.GetHashCode() == GetHashCode()) continue;
            if (item.getPoints().X == getPoints().X)
            {
                sameColumnBoxes.Add(item);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == "Breakable" && other.gameObject.tag == "Ball")
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            hitCount++;
            if (hitCount >= maxHits)
            {
                DestroyBlock();
            }
            else
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
        FindSameColumnBoxes();
        FallOtherBoxes(1);
        FallCharacter(1);
    }

    private PointF getPoints()
    {
        return new PointF(Convert.ToInt32(gameObject.transform.position.x),Convert.ToInt32(gameObject.transform.position.y));
    }

    private void FallCharacter(int fallAmount)
    {
        if ( Convert.ToInt32(character.transform.position.x) == getPoints().X)
        {
            
            character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y - fallAmount );
            if (Convert.ToInt32(character.transform.position.y) == boxHolderTopPosY)
            {
                character.GetComponent<SpriteRenderer>().sprite = sprites[0];
            }
        }
        
    }

    private void FallOtherBoxes(int fallAmount)
    {
        foreach (var item in sameColumnBoxes)
        {
            if (item == null || item.transform.position.y <= boxHolderTopPosY) continue;
            item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y - fallAmount);
        }
    }
}