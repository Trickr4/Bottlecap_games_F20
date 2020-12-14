using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    
    private Character _enemy;
    private float _maxHealth;
    
    void Start()
    {
        _enemy = transform.parent.GetComponent<Character>();
        _maxHealth = _enemy.hp;
    }

    void Update()
    {
        // Rotate the canvas to face the player.
        // Not fully working.
        // healthBar.transform.LookAt(Camera.main.transform);
        
        // Set the health amount.
        healthBar.fillAmount = _enemy.hp / _maxHealth;
    }
}
