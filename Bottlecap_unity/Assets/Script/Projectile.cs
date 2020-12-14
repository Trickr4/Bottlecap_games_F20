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
    public float fireDamageMultiplier;
    public float natureDamageMultiplier;
    public float waterDamageMultiplier;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _rigidbody.AddForce(_rigidbody.transform.up * projectileSpeed);
        Destroy(gameObject, projectileLifeSeconds);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Character enemyCharacter = other.gameObject.GetComponent<Character>();
            float currentMultiplier = 1f;
            
            // If the same elements then only do base damage.
            if (characterElement == enemyCharacter.characterElement)
            {
                enemyCharacter.hp -= baseDamage;
                // player.score += player.baseScore;
            }
            // TODO: Implement the damage multipliers.
            else
            {
                enemyCharacter.hp -= baseDamage * fireDamageMultiplier;
                currentMultiplier = fireDamageMultiplier;
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
