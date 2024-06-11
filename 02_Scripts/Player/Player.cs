using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public List<GameObject> playerList = new List<GameObject>();
    public Transform playerGroup;
    private HealthBar healthBar;


    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();  
    }

    private void Start()
    {
        healthBar.OnDamage += FollowPlayerDamage;
    }
    private void FollowPlayerDamage()
    {
        if(playerList.Count > 0) 
        {
            Debug.Log("Follow Player Die");
            playerList.RemoveAt(0);
            Destroy(playerGroup.GetChild(0).gameObject);
        }
    }
}
