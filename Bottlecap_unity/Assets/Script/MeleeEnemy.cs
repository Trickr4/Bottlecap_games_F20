using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Character
{
    private GameObject player;
    private Player playerStats;
    Rigidbody rb;
    private bool inRange = false;
    [SerializeField] protected float cooldown = 3f;
    private float atkspeed;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        dmg = 5;
        speed = 3;
        range = 1;

        atkspeed = cooldown;
        
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerStats = player.GetComponent<Player>();

        rb = GetComponent<Rigidbody>();
        animator = gameObject.transform.Find("Parts").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        if(!inRange)
            Move();
        if(atkspeed > 0)
            atkspeed -= time;
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
            animator.Play("Attack");
            inRange = true;
            if(atkspeed < 0)
            {
                playerStats.setHP(playerStats.getHP()-dmg);
                atkspeed = cooldown;
            }
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other) {
        inRange = false;
    }

}
