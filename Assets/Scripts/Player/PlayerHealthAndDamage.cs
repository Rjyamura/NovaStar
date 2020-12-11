﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthAndDamage : MonoBehaviour
{
    [SerializeField]
    public float health = 1;
    [SerializeField]
    public float maximumHealth = 1;

    private PlayerWeaponsFire _playerWeapon;
    private SpawnManager _spawnManager;
    private void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("Missing Spawn Manager");
        }

        _playerWeapon = GameObject.Find("Player").GetComponent<PlayerWeaponsFire>();
        if (_playerWeapon == null)
        {
            Debug.LogError("Player Weapon is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ///PlayerDamageTest();
    }


    public void PlayerDamage()
    {
        health -= .5f;
        _playerWeapon._weaponPowerUpID = 0;

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            health = 5f;
        }
    }

    //for testing
    public void PlayerDamageTest()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerDamage();
            //Debug.Log("Health= " + health);
        }
    }

    public bool getPlayerStatus()
    {
        return this.gameObject.activeSelf;
    }
}

