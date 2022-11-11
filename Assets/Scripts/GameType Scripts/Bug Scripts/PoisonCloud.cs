using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloud : MonoBehaviour
{
    public float poisonDamage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Tags.HasTag(collision.gameObject, "plant"))
        {
            collision.gameObject.GetComponent<GameType>().Damage(poisonDamage);
        }
    }

}
