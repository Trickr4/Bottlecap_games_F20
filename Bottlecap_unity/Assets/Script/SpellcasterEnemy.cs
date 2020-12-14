using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellcasterEnemy : Character
{
    protected GameObject player;
    protected Player playerStats;
    Rigidbody rb;
    [SerializeField] GameObject spell;
    [SerializeField] float cooldown;
    private float spellcd;

    public float castDelay;
    public float castDuration;
    private float moving = 2;
    [SerializeField] float moveTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        dmg = 5;
        speed = 3;
        range = 1;
        moving = moveTime;
        cooldown = 10;
        spellcd = cooldown;
        RandDir(Random.Range(-179.0f, 179.0f));
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerStats = player.GetComponent<Player>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        Move();
        if(spellcd <= 0)
        {
            castSpell();
            spellcd = cooldown;
        }
        else
        {
            spellcd -= time;
        }
        if(moveTime<0)
        {
            RandDir(Random.Range(-179.0f, 179.0f));
            moveTime = moving;
        }
        moveTime -= time;
    }

    private void Move()
    {
        transform.position += transform.forward * 3.0f * Time.deltaTime;
    }

    private void RandDir(float dir)
    {
        transform.rotation = Quaternion.Euler(0,dir,0);
    }

    private Vector3 GetPlayerPos()
    {
        return Vector3.Normalize( (player.transform.position) );
    }

    private void castSpell()
    {
        GameObject casted = Instantiate(spell, player.transform.position, Quaternion.identity);
        casted.GetComponent<Spell>().spellcaster = gameObject;
    }
}
