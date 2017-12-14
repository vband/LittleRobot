using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Light Saber", fileName = "LightSaberDefault")]
public class LightSaber : Weapon
{
    private void Awake()
    {
        Damage = 1f;
    }

    public override Transform Attack(Transform attackHitBoxPrefab, Transform transform, Vector3 facingDirectionVector)
    {
        Transform instance = Instantiate(
            attackHitBoxPrefab,
            new Vector3(transform.position.x + facingDirectionVector.x, transform.position.y + facingDirectionVector.y, 0f),
            Quaternion.identity);
        instance.gameObject.tag = "AttackHitBox";
        instance.GetComponent<AttackHitBox>().damage = this.Damage;
        return instance;
    }
}
