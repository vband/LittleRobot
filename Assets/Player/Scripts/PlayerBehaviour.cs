using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehaviour : CreatureBehaviour
{
    public float CurrentLife {get{return life;}}

    [SerializeField]
    private Vector2 inputVector;
    private Vector2 facingDirectionVector;

    [SerializeField]
    private Transform attackHitBoxPrefab;

    private bool isInvincible, hasLightsaber, isAttacking;

    public Action onAttacked;
    public Action onDied;

    

	new private void Start ()
    {
        base.Start();        
        inputVector = new Vector2();
        facingDirectionVector = new Vector2(0, -1);
        movementSpeed = 2.0f;
        life = 5.0f;
        isInvincible = false;
        hasLightsaber = false;
	}

	void Update ()
    {
        HandleInput();
        UpdateFacingDirectionVector();
	}

    void FixedUpdate()
    {
        Move();
        HandleAnimation();
    }

    private void HandleInput()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");

        if (!isAttacking && Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());
            //Debug.Break();
        }
    }

    private void UpdateFacingDirectionVector()
    {
        if (inputVector.magnitude > 0)
        {
            facingDirectionVector = inputVector.normalized;
        }
    }

    private void Move()
    {
        rb.velocity = movementSpeed * inputVector;
    }

    private void HandleAnimation()
    {
        if (inputVector.x > 0 && inputVector.y == 0)
        {
            anim.SetBool("right", true);
        }
        else if (inputVector.x <= 0)
        {
            anim.SetBool("right", false);
        }

        if (inputVector.x < 0 && inputVector.y == 0)
        {
            anim.SetBool("left", true);
        }
        else if (inputVector.x >= 0)
        {
            anim.SetBool("left", false);
        }

        if (inputVector.y > 0 && inputVector.x == 0)
        {
            anim.SetBool("up", true);
        }
        else if (inputVector.y <= 0)
        {
            anim.SetBool("up", false);
        }

        if (inputVector.y < 0 && inputVector.x == 0)
        {
            anim.SetBool("down", true);
        }
        else if (inputVector.y >= 0)
        {
            anim.SetBool("down", false);
        }

        if (hasLightsaber)
        {
            anim.SetBool("lightSaber", true);
        }       
    }

    public void GetAttacked(float damage, float attackKnockbackStrength, Vector2 enemyPosition)
    {
        onAttacked();
        if (!isInvincible)
        {            
            this.life -= (float)damage;
            if(life <= 0)
            {
                onDied();
                return;
            }
            StartCoroutine(Knockback(enemyPosition, attackKnockbackStrength));
            StartCoroutine(Invincible());
        }
        // print("Damage " + damage);
        // print("Attack Knockback Strength " + attackKnockbackStrength);
        // print("Attack Direction" + (enemyPosition - (Vector2) transform.position));
         //print("Life " + this.life);
    }

    private IEnumerator Knockback(Vector2 enemyPosition, float attackKnockbackStrength)
    {
        Vector2 distance = enemyPosition - (Vector2) transform.position;
        float counter = 1.0f;
        while (distance.magnitude < 2.0f)
        {
            // print(distance.magnitude);
            distance = enemyPosition - (Vector2)transform.position;
            rb.AddForce(-1 * distance.normalized * attackKnockbackStrength * counter);
            counter += 1.0f;
            yield return new WaitForFixedUpdate(); 
        }
    }

    private IEnumerator Invincible()
    {
        isInvincible = true;
        anim.SetBool("isInvincible", true);

        yield return new WaitForSeconds(1.5f);

        isInvincible = false;
        anim.SetBool("isInvincible", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
            GetItem();
        }
    }

    private void GetItem()
    {
        hasLightsaber = true;
        weapon = (LightSaber) ScriptableObject.CreateInstance("LightSaber");
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        anim.SetTrigger("attack");
        if (weapon != null)
        {
            Transform attack = weapon.Attack(attackHitBoxPrefab, this.transform, facingDirectionVector);
            if (attack != null)
            {
                yield return new WaitForSeconds(0.10f);
                Destroy(attack.gameObject);
                
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }
        isAttacking = false;
    }
}
