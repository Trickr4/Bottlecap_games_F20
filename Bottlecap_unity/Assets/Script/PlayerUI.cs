using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Player player;

    private Text _healthText;
    private Text _scoreText;
    private float _originalPlayerHealth;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        _healthText = GameObject.FindWithTag("HealthUI").GetComponent<Text>();
        _scoreText = GameObject.FindWithTag("ScoreUI").GetComponent<Text>();
        
        _originalPlayerHealth = player.hp;
    }

    void Update()
    {
        _healthText.text = $"Health: {Mathf.RoundToInt(player.hp)}";
        _scoreText.text = $"Score: {player.score:000000}";
        _healthText.color = Color.Lerp(Color.green, Color.red, (_originalPlayerHealth - player.hp) / 100);
    }
}
