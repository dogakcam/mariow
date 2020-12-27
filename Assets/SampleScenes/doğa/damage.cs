﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    
    public int Hurt = 1;

    /*
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Someone touched me");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player touched me");
            Vector3 damageDirection = collision.transform.position + transform.position;
            damageDirection = damageDirection.normalized;
            FindObjectOfType<playerhealth>().DamagePlayer(Hurt, damageDirection);
        }
    }
    */

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player touched me");
            Vector3 damageDirection = other.transform.position + transform.position;
            damageDirection = damageDirection.normalized;
            FindObjectOfType<playerhealth>().DamagePlayer(Hurt, damageDirection);
        }
    }
}
