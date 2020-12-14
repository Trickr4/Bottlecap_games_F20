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
    
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        _healthText = GameObject.FindWithTag("HealthUI").GetComponent<Text>();
        _scoreText = GameObject.FindWithTag("ScoreUI").GetComponent<Text>();
    }

    void Update()
    {
        _healthText.text = $"Health: {Mathf.RoundToInt(player.hp)}";
        _scoreText.text = $"Score: {player.score:000000}";
    }
}
