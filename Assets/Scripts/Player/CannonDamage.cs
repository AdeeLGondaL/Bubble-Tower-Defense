using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // Game Over (Lose)

            Debug.Log("You Lose");
        }
    }
}
