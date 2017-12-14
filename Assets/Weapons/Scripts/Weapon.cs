using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Weapon", fileName = "WeaponDefault")]
public class Weapon : ScriptableObject {

    private bool type; // Melee, Ranged ?
    private float damage;
    private float attackKnockbackStrength;
    private List<Effect> effects;

    #region Getters & Setters
    public float Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    public float AttackKnockbackStrength
    {
        get
        {
            return attackKnockbackStrength;
        }
        set
        {
            attackKnockbackStrength = value;
        }
    }
    public List<Effect> Effects
    {
        get
        {
            return effects;
        }
        set
        {
            effects = value;
        }
    }
    #endregion

    // This function is called when the ScriptableObject script is started.
    void Awake () {
		
	}

    // This function is called when the scriptable object will be destroyed.
    void OnDestroy () {
		
	}

    // This function is called when the scriptable object goes out of scope.
    void OnDisable()
    {

    }

    // This function is called when the object is loaded.
    void OnEnable()
    {

    }

    public virtual Transform Attack()
    {
        return null;
    }
    public virtual Transform Attack(Transform attackHitBoxPrefab, Transform transform, Vector3 facingDirectionVector)
    {
        return null;
    }
}
