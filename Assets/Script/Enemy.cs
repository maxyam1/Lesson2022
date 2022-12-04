using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int hp = 100;

    public void TakeDamage(int damage) 
    {
        hp = hp - damage;
        if (hp <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
