using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject spawnPoint;
    public float speed = 10.0f;

    private Vector3 normalScale = new Vector3(1, 1, 1);
    private Vector3 flipScale = new Vector3(-1, 1, 1);

    private bool movingR = false;
    private bool movingL = false;
    private bool movingU = false;
    private bool movingD = false;
    private bool block = false;
    private bool attack = false;
    private bool die = false;
    private bool diePlaying = false;

    private Rigidbody2D rbody;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        rbody = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        Respawn();
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!diePlaying && !die)
        {
            Vector2 movement = new Vector2();
            if (movingR)
            {
                movement.x = speed;
                this.gameObject.transform.localScale = normalScale;
            }
            if (movingL)
            {
                movement.x = -speed;
                this.gameObject.transform.localScale = flipScale;
            }
            if (movingU)
            {
                movement.y = speed;
            }
            if (movingD)
            {
                movement.y = -speed;
            }

            rbody.velocity = movement.normalized * this.speed;

            animator.SetFloat("speedHorizontal", rbody.velocity.x);
            animator.SetFloat("speedVertical", rbody.velocity.y);

            if (block)
            {
                animator.SetTrigger("block");
                block = false;
            }

            if (attack)
            {
                animator.SetTrigger("slash");
                attack = false;
            }
        }
        else
        {
            if (die)
            {
                diePlaying = true;
                animator.SetTrigger("die");
                die = false;
            }

            AnimatorStateInfo stateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Death") && stateInfo.normalizedTime >= 1.5f)
            {
                Respawn();
            }
        }
    }

    public void MoveRight(bool movingR)
    {
        this.movingR = movingR;
    }

    public void MoveLeft(bool movingL)
    {
        this.movingL = movingL;
    }

    public void MoveDown(bool movingD)
    {
        this.movingD = movingD;
    }

    public void MoveUp(bool movingU)
    {
        this.movingU = movingU;
    }

    public void Block()
    {
        this.block = true;
    }

    public void Attack()
    {
        this.attack = true;
    }

    public void Die()
    {
        this.die = true;

    }

    public void Respawn()
    {
        this.gameObject.SetActive(false);
        this.gameObject.transform.position = spawnPoint.transform.position;
        Init();
    }

    private void Init()
    {
        this.movingR = false;
        this.movingL = false;
        this.block = false;
        this.attack = false;
        this.die = false;
        this.diePlaying = false;
        if (this.animator.isInitialized)
        {
            this.animator.Rebind();
        }
        this.gameObject.SetActive(true);
    }
}
