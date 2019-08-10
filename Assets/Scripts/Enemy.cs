﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    public int damage = 1;

    // Start is called before the first frame update


    void Update()
    {
        DoAI();
    }

    public abstract void DoAI();

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "player")
        {
            col.gameObject.GetComponent<Player>().Hurt(1, 1f);
        }
    }
}
