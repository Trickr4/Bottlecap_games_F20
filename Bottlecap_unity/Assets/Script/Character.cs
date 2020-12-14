using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    public Enums.ELEMENT_TYPES characterElement;
    public float hp;
    public int score;
    public int baseScore = 10; // Will use the damage multipliers to increase the score.

    protected float dmg;
    [SerializeField] protected float speed;
    [SerializeField] protected Sprite image;
    //range is times 100 px
    protected float range;
    
    public float getHP(){return hp;}
    public void setHP(float num){hp = num;}
    public float getDMG(){return dmg;}
    public void setDMG(float num){dmg = num;}
    public float getSPEED(){return speed;}
    public void setSPEED(float num){speed = num;}
    /* change the character model... not done
    public void setIMAGE(){return null;}*/
    public float getRANGE(){return range;}
    public void setRANGE(float num){range = num;;}

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GameObject.Find("Audio Effects").transform.Find("EnemyDeath").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (hp <= 0)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                audioSource.Play();

            }
            
            if (gameObject.CompareTag("Player"))
            {
                ShowDeathScreen();
            }
            
            Destroy(gameObject);
        }
    }

    private void ShowDeathScreen()
    {
        // Hide the player HUD.
        GameObject.FindWithTag("PlayerHUD").SetActive(false);
        
        // Show the death screen.
        GameObject.FindWithTag("PlayerUIManager").GetComponent<PlayerUI>().SetDeathScreenActive();
    }
}
