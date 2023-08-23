using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // Game Over (Lose)
            GameManager.Instance.GameLost();
            Debug.Log("You Lose");
        }
    }
}
