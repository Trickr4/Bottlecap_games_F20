using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHurtBox : MonoBehaviour
{
    protected GameObject player;
    protected Player playerStats;
    private bool damaged = false;
    private float dmg;
    public GameObject spellcaster;
    void Start()
    {

        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerStats = player.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other) {
        //add an attack cooldown here or put iframes on the player.
        
        if(other.CompareTag("Player") && !damaged)
        {
            Debug.Log(other);
            playerStats.setHP(playerStats.getHP()-spellcaster.GetComponent<SpellcasterEnemy>().getDMG());
            Debug.Log(playerStats.getHP());
            damaged = true;
        }
    }
}
