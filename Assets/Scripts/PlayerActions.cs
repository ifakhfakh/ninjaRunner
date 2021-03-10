using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    public GameObject player;

    public Text winText;

    public GameObject kunai;

    public GameObject retstart;

    private Animator animator;

    public int flyForce;

    private Rigidbody2D rb;

    private int numberOfBarrelsDestroyed = 0;

    private Boolean isOnGround = true;

    private Transform tra;

    private int isColliding = 0;

    public float speed;
    public float force;
    void Start()
    {
        Time.timeScale = 1;
        rb = player.GetComponent<Rigidbody2D>();
        tra = player.GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        move(h);
        attack();
        jump(h);
        fly();
    }

    public void move(float h)
    {

        if (h != 0 && isOnGround)
        {
            animator.SetBool("isRunning", true);
            rb.velocity = Vector2.right * h * Time.deltaTime * speed;
            if (h > 0)
            {

                tra.rotation = Quaternion.Euler(Vector3.up * 0);
            }
            else
            {
                tra.rotation = Quaternion.Euler(Vector3.up * 180);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    public void attack()
    {
        if (Input.GetAxis("Fire2") != 0)
        {
            Debug.Log("attack");
            animator.SetBool("isAttacking", true);

        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

    }

    public void jump(float h)
    {
        if (Input.GetAxisRaw("Jump") != 0 && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(new Vector2(h, 1) * force * Time.deltaTime);
        }
    }
    public void fly()
    {
        if (Input.GetAxisRaw("fly") != 0 && numberOfBarrelsDestroyed == 4)
        {
            isOnGround = false;
            animator.SetBool("isFlying", true);
            rb.AddForce(new Vector2(0.5f, 0.5f) * flyForce * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isFlying", false);
            if (isColliding != 0)
            {
                isOnGround = true;
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "greenBarrel" && animator.GetBool("isAttacking"))
        {
            Debug.Log("collider");
            Destroy(col.gameObject);
            numberOfBarrelsDestroyed++;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        isColliding--;
        if (isColliding == 0)
        {
            isOnGround = false;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        isColliding++;
        if (col.gameObject.tag == "danger")
        {
            Dead();
        }
        if (col.gameObject.tag == "ground")
        {
            isOnGround = true;
        }
        if (col.gameObject.name == "DoorOpen1")
        {
            SceneManagement sceneManagement = FindObjectOfType<SceneManagement>();
            sceneManagement.nextScene();
        }

        if (col.gameObject.name == "DoorOpen2")
        {
            winText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnBecameInvisible()
    {
        Debug.Log("dead2");
        Dead();
    }

    public void Dead()
    {
        animator.SetBool("isDead", true);
        Time.timeScale = 0;
        if (retstart != null)
        {
            retstart.SetActive(true);
        }

    }
}

