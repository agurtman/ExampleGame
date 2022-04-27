using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public Animator animator;
    private GameObject player;
    public float findRadius = 30;
    public float speed = 2;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < findRadius)
        {
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * speed);
            animator.SetBool("Walk", true);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        GetComponent<CharacterController>().enabled = false;
        animator.SetTrigger("Dead");
        Destroy(gameObject, 10);
    }
}
