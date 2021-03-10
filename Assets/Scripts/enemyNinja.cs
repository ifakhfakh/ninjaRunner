using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyNinja : MonoBehaviour
{
    public GameObject ninja;
    private PlayerActions playerActions;

    public float speed;

    private Animator animator;

    private Vector2 distanceSep;

    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerActions = FindObjectOfType<PlayerActions>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", true);
        distanceSep = transform.position - ninja.transform.position;
        if (distanceSep.x > 0)
        {
            rb.velocity = -Vector2.right * speed * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(Vector3.up * 180);

        }
        else
        {
            rb.velocity = Vector2.right * speed * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(Vector3.up * 0);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ninja" && ninja.GetComponent<Animator>().GetBool("isAttacking"))
        {
            Destroy(gameObject);
        }

    }

}
