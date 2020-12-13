using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Character
{
    private GameObject player;
    private Player playerStats;
    Rigidbody rb;
    private bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        dmg = 5;
        speed = 3;
        range = 1;

        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerStats = player.GetComponent<Player>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!inRange)
            Move();
    }

    private void Move()
    {
        transform.LookAt(player.transform.position);
        transform.position += transform.forward * 3.0f * Time.deltaTime;
    }

    private void Attack()
    {
        if(Vector2.Distance(GetPlayerPos(), transform.position) == 3f)
        {
            //player loses hp - dmg
            playerStats.setHP(-(dmg));
        }
    }

    //AI lock on to player.
    private Vector3 GetPlayerPos()
    {
        return Vector3.Normalize( (player.transform.position) );
    }

    private void OnTriggerStay(Collider other) {
        //add an attack cooldown here or put iframes on the player.
        
        if(other.CompareTag("Player"))
        {
            inRange = true;
            playerStats.setHP(playerStats.getHP()-dmg);
            Debug.Log(other);
            Debug.Log(playerStats.getHP());
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other) {
        inRange = false;
    }

}
