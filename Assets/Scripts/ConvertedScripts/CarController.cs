﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : PossesableObject
{

    public bool goingLeft = false;
    public bool isCramped = false;
    

    // Update is called once per frame
    void Update()
    {
        Control();
    }

    void Control()
    {
        if (isPossesed)
        {
            //controller.transSound.Play ();
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * Time.deltaTime * 4);
                goingLeft = false;
                if (!goingLeft)
                {
                    gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.right * Time.deltaTime * 4 * -1);
                goingLeft = true;
                if (goingLeft)
                {
                    gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (isCramped)
                {
                    return;
                }

                Vector3 spawnPoint = transform.position;
                spawnPoint.y += 1.1f;

                player.transform.position = spawnPoint;

                PlatformerMotor2D pm2 = player.GetComponent<PlatformerMotor2D>();
                pm2.Jump();

                UnPosssessThis();

            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            assignPlayer(other);
        }

        if (other.gameObject.CompareTag("Couch"))
        {
            isCramped = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (isPossesed && other.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            removePlayer();
        }

        if (other.gameObject.CompareTag("Couch"))
        {
            isCramped = false;
        }
    }

}
