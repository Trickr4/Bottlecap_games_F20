using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemies
{
    private GameObject player;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        dmg = 5;
        speed = 3;
        range = 1;

        player = GameObject.FindGameObjectsWithTag("Player")[0];
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Vector3.Distance(GetPlayerPos(), transform.position) == range) 
        {
            Attack();
        }
    }

    private void Move()
    {
        transform.LookAt(player.transform.position);
        transform.position += transform.forward * 3.0f * Time.deltaTime;
    }

    private void Attack()
    {
        //player.transform;
    }

    //AI lock on to player.
    private Vector3 GetPlayerPos()
    {
        return Vector3.Normalize( (player.transform.position) );
    }

}
