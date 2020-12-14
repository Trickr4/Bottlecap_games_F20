using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Character
{
    private GameObject player;
    private Player playerStats;
    Rigidbody rb;
    private bool inRange = false;
    [SerializeField] float cooldown;
    private float reload;

    public GameObject projectile;

    private float moving = 2;
    [SerializeField] float moveTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        dmg = 5;
        speed = 3f;
        range = 1;
        moving = moveTime;
        cooldown = 2;
        reload = cooldown;
        RandDir(Random.Range(-179.0f, 179.0f));
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerStats = player.GetComponent<Player>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        float time = Time.deltaTime;
        if(reload <= 0)
        {
            Fire();
            reload = cooldown;
        }
        else
        {
            reload -= time;
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

    void Fire()
    {
        transform.LookAt(player.transform.position);
        GameObject spawnedGameObject = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
        Projectile spawnedProjectile = spawnedGameObject.GetComponent<Projectile>();
        spawnedProjectile.projectileSpeed = 500;
    }
}
