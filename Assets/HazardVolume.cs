using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardVolume : MonoBehaviour
{
    public int damageTaken = 10;
    playerMovement player;
    public void OnTriggerEnter(Collider  other)
    {
        playerMovement player
          = other.gameObject.GetComponent<playerMovement>();
        if (player != null)
        {
            //insert instant KO
           // player.TakeDamage(damageTaken);
        }
    }
}
