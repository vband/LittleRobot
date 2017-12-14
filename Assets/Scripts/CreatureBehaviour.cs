using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehaviour : MonoBehaviour {

    protected float life;
    [SerializeField]
    protected Weapon weapon;
    [SerializeField]
    protected float movementSpeed;

    #region Components
    protected Rigidbody2D rb;
    protected Animator anim;
    #endregion

    protected void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        if (!anim) anim = GetComponent<Animator>();
    }
}
