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

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        dmg = 5;
        speed = 3;
        range = 1;

        cooldown = 10;
        spellcd = cooldown;

        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerStats = player.GetComponent<Player>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        if(spellcd <= 0)
        {
            castSpell();
            spellcd = cooldown;
        }
        else
        {
            spellcd -= time;
        }
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
