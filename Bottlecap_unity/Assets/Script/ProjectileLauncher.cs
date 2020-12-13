using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile;

    private AudioSource audioSource;
    private Animator animator;

    private void Start()
    {
        animator = gameObject.transform.parent.transform.Find("Parts").GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        // More efficient than accessing transform multiple times.
        Transform currentTransform = transform;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
            animator.Play("Attack", 0, 0f);
            GameObject spawnedGameObject = Instantiate(projectile, currentTransform.position,
                    currentTransform.rotation);
            
            // Set the element type of the player on the projectile.
            Projectile spawnedProjectile = spawnedGameObject.GetComponent<Projectile>();
            Character player = currentTransform.parent.gameObject.GetComponent<Character>();
            
            spawnedProjectile.characterElement = player.characterElement;
        }
    }
}
