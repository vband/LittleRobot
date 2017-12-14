using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : CreatureBehaviour
{
    [SerializeField]
    private float aggroRadius;
    private States state;
    private Transform target;
    //private BasicWeapon weapon;

    private enum States
    {
        Idle,
        Chase
    };

    new private void Start ()
    {
        base.Start();
        weapon = (BasicWeapon)ScriptableObject.CreateInstance("BasicWeapon");
        weapon.AttackKnockbackStrength = 10.0f;
        movementSpeed = 1.0f;
        aggroRadius = 5.0f;
        life = 1;
    }
	
	void FixedUpdate ()
    {
		switch (state)
        {
            case States.Idle:
                DetectTarget();
                break;

            case States.Chase:
                ChaseTarget();
                break;
        }
	}

    private void DetectTarget()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, aggroRadius, Vector2.zero);

        if (hit.collider != null && hit.collider.tag == "Player")
        {
            target = hit.collider.transform;
            anim.SetBool("isWalking", true);
            state = States.Chase;
        }
    }

    private void ChaseTarget()
    {
        Vector2 movementDirection = target.position - transform.position;
        rb.velocity = movementDirection.normalized * movementSpeed;
    }

    private void AttackPlayer(PlayerBehaviour player)
    {        
        player.GetAttacked(weapon.Damage, weapon.AttackKnockbackStrength, transform.position);
        // player.GetComponent<Rigidbody2D>().AddForce(attackDirection.normalized * weapon.AttackKnockbackStrength);
    }

    private bool IsColliderObjectPlayer(Collision2D collision)
    {
        //return collision.gameObject.tag == "Player";
        return collision.gameObject.layer == 9;
    }

    private bool IsColliderAnAttackFromPlayer(Collision2D collision)
    {
        //return collision.gameObject.tag == "AttackHitBox";
        return collision.gameObject.layer == 8;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsColliderObjectPlayer(collision))
        {
            AttackPlayer(collision.gameObject.GetComponent<PlayerBehaviour>());
        }

        else if (IsColliderAnAttackFromPlayer(collision))
        {
            ReceveDamage(collision.gameObject.GetComponent<AttackHitBox>().damage);
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        //print(collision.gameObject.name);
        if (IsColliderObjectPlayer(collision))
        {
            AttackPlayer(collision.gameObject.GetComponent<PlayerBehaviour>());
        }
    }

    private void ReceveDamage(float damage)
    {
        //print("AI AI! " + damage + " " + Life);

        life = life - damage;

        if (life <= 0)
        {
            //print("AAAAAAAAAAAAAAAAAAAAI!!!!");
            Destroy(gameObject);
        }
    }
}
