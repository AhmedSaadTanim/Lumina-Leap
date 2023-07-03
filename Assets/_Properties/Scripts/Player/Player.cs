using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerAnimation playerAnimation;
    public PlayerStats playerStats;
    public PlayerMovement playerMovement;

    void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerStats = GetComponent<PlayerStats>();
        playerMovement = GetComponent<PlayerMovement>();
    }
}
