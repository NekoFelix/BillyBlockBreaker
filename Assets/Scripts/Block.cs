using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockBreakSound;
    [SerializeField] GameObject blockParticleVFX;
    [SerializeField] Sprite[] damagedSprites;
  
    [SerializeField] int dmgTaken;


    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 3)
        {
            if (tag == "Breakable")
            {
                FindObjectOfType<LevelState>().BlocksCount();
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            dmgTaken++;
            int blockHP  = damagedSprites.Length + 1;

            AudioSource.PlayClipAtPoint(blockBreakSound, transform.position);
            if (dmgTaken >= blockHP)
            {
                DestroyBlock();
            }
            else
            {
                ShowDamagedSprite();
            }
        }
    }

    private void ShowDamagedSprite()
    {
        int indexDamagedSprites = dmgTaken - 1;
        if (damagedSprites[indexDamagedSprites] != null)
        {
            GetComponent<SpriteRenderer>().sprite = damagedSprites[indexDamagedSprites];
        }
        else 
        {
            Debug.LogError("Sprite is missing: " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 3)
        {
            FindObjectOfType<Score>().AddToScore();
            FindObjectOfType<LevelState>().BreakBlock();
            
            Destroy(gameObject, 0.05f);
            TriggerBlockParticle();
        }
    }

    private void TriggerBlockParticle()
    {
        GameObject blockParticle = Instantiate(blockParticleVFX, transform.position, transform.rotation);
        Destroy(blockParticle.gameObject, 2f);
    }
}
