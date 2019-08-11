﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerEnemy : Enemy
{
    public bool pursuePlayer;
    public float pursuePlayerRange;
    bool aggro;
    public float yTolerance;


    public float TEMP_FIRE_COOLDOWN_MAX = 1f;
    public float TEMP_FIRE_COOLDOWN = 0;
    public override void DoAI()
    {
        if (aggro)
        {
            fightPlayer();
        }
        else
        {
            if (Vector2.Distance(GameObject.FindGameObjectWithTag("player").transform.position, this.transform.position) < pursuePlayerRange)
            {
                aggro = true;
            }
            else
            {
                patrol();
            }
        }
    }

    public void fightPlayer()
    {
        TEMP_FIRE_COOLDOWN -= Time.deltaTime;

        // face player if we arent.
        bool playerDir = GameObject.FindGameObjectWithTag("player").transform.position.x > this.transform.position.x;
        if(facedRight != playerDir)
        {
            Move(facedRight ? -1 : 1);
        } else
        {
            // we are facing player. Now, see if we are on the same Y plane.
            float ydiff = GameObject.FindGameObjectWithTag("player").transform.position.y - this.transform.position.y;

            if (Mathf.Abs(ydiff) < yTolerance)
            {
                if (TEMP_FIRE_COOLDOWN < 0)
                {
                    TEMP_FIRE_COOLDOWN = TEMP_FIRE_COOLDOWN_MAX;
                    // Can shoot player.
                    FirePrimary();
                }
            } else
            {
                if (ydiff > 0)
                {
                    Debug.Log("jump");
                    // Jump to get into position. 
                    Jump();
                }
            }
        }
        
    }


}