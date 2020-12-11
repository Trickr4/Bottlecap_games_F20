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
            Character player = other.gameObject.GetComponent<Character>();
            
            // If the same elements then only do base damage.
            if (characterElement == player.characterElement)
            {
                player.hp -= baseDamage;
            }
            // TODO: Implement the damage multipliers.
            else
            {
                player.hp -= baseDamage * fireDamageMultiplier;
            }
            
            Destroy(gameObject);
        }
    }
}
