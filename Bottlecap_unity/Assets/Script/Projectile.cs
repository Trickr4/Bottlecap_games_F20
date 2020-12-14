using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public Enums.ELEMENT_TYPES characterElement;
    
    public float projectileSpeed;
    public float projectileLifeSeconds;
    public float baseDamage;
    public float strongDamageMultiplier = 2f;
    public float weakDamageMultiplier = 0.5f;

    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _rigidbody.AddForce(_rigidbody.transform.up * projectileSpeed);
        Destroy(gameObject, projectileLifeSeconds);
        _audioSource = GameObject.Find("Audio Effects").transform.Find("EnemyDamage").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(gameObject.tag == "Enemy" && other.tag == "Player")
        {
            
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            Player playerStats = player.GetComponent<Player>();
            
            // If the same elements then only do base damage.
            if (characterElement == playerStats.characterElement)
            {
                playerStats.setHP(playerStats.getHP()-baseDamage);
            }
            else
            {
                switch(characterElement)
                {
                    case Enums.ELEMENT_TYPES.Fire:
                        if(playerStats.characterElement == Enums.ELEMENT_TYPES.Water)
                        {
                            playerStats.setHP(playerStats.getHP()-(baseDamage* weakDamageMultiplier));
                        }
                        else
                        {
                             playerStats.setHP(playerStats.getHP()-(baseDamage* strongDamageMultiplier));
                        }
                        break;
                    case Enums.ELEMENT_TYPES.Water:
                        if(playerStats.characterElement == Enums.ELEMENT_TYPES.Nature)
                        {
                            playerStats.setHP(playerStats.getHP()-(baseDamage* weakDamageMultiplier));
                        }
                        else
                        {
                             playerStats.setHP(playerStats.getHP()-(baseDamage* strongDamageMultiplier));
                        }
                        break;
                    case Enums.ELEMENT_TYPES.Nature:
                        if(playerStats.characterElement == Enums.ELEMENT_TYPES.Fire)
                        {
                            playerStats.setHP(playerStats.getHP()-(baseDamage* weakDamageMultiplier));
                        }
                        else
                        {
                             playerStats.setHP(playerStats.getHP()-(baseDamage* strongDamageMultiplier));
                        }
                        break;
                }
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy") && gameObject.tag == "Projectile")
        {
            _audioSource.Play();
            Character enemyCharacter = other.gameObject.GetComponent<Character>();
            float currentMultiplier = 1f;
            
            // If the same elements then only do base damage.
            if (characterElement == enemyCharacter.characterElement)
            {
                enemyCharacter.hp -= baseDamage;
            }
            else
            {
                switch(characterElement)
                {
                    case Enums.ELEMENT_TYPES.Fire:
                        if(enemyCharacter.characterElement == Enums.ELEMENT_TYPES.Water)
                        {
                            enemyCharacter.hp -= (baseDamage* weakDamageMultiplier);
                        }
                        else
                        {
                            enemyCharacter.hp -= (baseDamage* strongDamageMultiplier);
                        }
                        break;
                    case Enums.ELEMENT_TYPES.Water:
                        if(enemyCharacter.characterElement == Enums.ELEMENT_TYPES.Nature)
                        {
                            enemyCharacter.hp -= (baseDamage* weakDamageMultiplier);
                        }
                        else
                        {
                            enemyCharacter.hp -= (baseDamage* strongDamageMultiplier);
                        }
                        break;
                    case Enums.ELEMENT_TYPES.Nature:
                        if(enemyCharacter.characterElement == Enums.ELEMENT_TYPES.Fire)
                        {
                            enemyCharacter.hp -= (baseDamage* weakDamageMultiplier);
                        }
                        else
                        {
                            enemyCharacter.hp -= (baseDamage* strongDamageMultiplier);
                        }
                        break;
                }
            }
            
            Destroy(gameObject);
            
            // Add points to player if needed.
            if (enemyCharacter.hp < 0)
            {
                Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
                player.score += Mathf.RoundToInt(player.baseScore * currentMultiplier);
            }
        }
    }
}
