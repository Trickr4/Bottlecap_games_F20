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

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        dmg = 5;
        speed = 3;
        range = 1;

        cooldown = 2;
        reload = cooldown;

        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerStats = player.GetComponent<Player>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
    void Fire()
    {
        transform.LookAt(player.transform.position);
        GameObject spawnedGameObject = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
        Projectile spawnedProjectile = spawnedGameObject.GetComponent<Projectile>();
        spawnedProjectile.projectileSpeed = 500;
    }
}
