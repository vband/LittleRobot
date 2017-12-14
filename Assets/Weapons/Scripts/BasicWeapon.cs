using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Basic Weapon", fileName = "BasicWeaponDefault")]
public class BasicWeapon : Weapon
{

    // This function is called when the ScriptableObject script is started.
    void Awake()
    {
        Damage = 1.0f;
        AttackKnockbackStrength = 10f;
    }

    // This function is called when the scriptable object will be destroyed.
    void OnDestroy()
    {

    }

    // This function is called when the scriptable object goes out of scope.
    void OnDisable()
    {

    }

    // This function is called when the object is loaded.
    void OnEnable()
    {

    }
}
