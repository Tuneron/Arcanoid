using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Player Pl;
    AudioSource As;
    Rigidbody Rg;
    bool ballInGame;

    const float MAX_SPEED_POS = 6.5f;
    const float MAX_SPEED_NEG = -6.5f;

    void Start()
    {
        Pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        As = GetComponent<AudioSource>();
        Rg = GetComponent<Rigidbody>();
        Rg.isKinematic = true;
        ballInGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !ballInGame)
        {
            ballInGame = true;
            Rg.isKinematic = false;
            Rg.velocity = new Vector3(6f, 6f, 0);
        }

        if (!ballInGame)
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 0.5f, 0);

        if (transform.position.y < -4.75f)
        {
            As.Play();
            Pl.RemoveHp();
            ballInGame = false;
        }

        if (Rg.velocity.x > MAX_SPEED_POS || Rg.velocity.x == 0)
            Rg.velocity = new Vector3(MAX_SPEED_POS, Rg.velocity.y, 0);
        else
              if (Rg.velocity.y > MAX_SPEED_POS || Rg.velocity.y == 0)
            Rg.velocity = new Vector3(Rg.velocity.x, MAX_SPEED_POS, 0);

        if (Rg.velocity.x < MAX_SPEED_NEG || Rg.velocity.x == 0)
            Rg.velocity = new Vector3(MAX_SPEED_NEG, Rg.velocity.y, 0);
        else
            if (Rg.velocity.y < MAX_SPEED_NEG || Rg.velocity.y == 0)
            Rg.velocity = new Vector3(Rg.velocity.x, MAX_SPEED_NEG, 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if ((Random.value * 2) > 1)
                Rg.velocity = new Vector3(2f + Random.value * 4.5f, 5.5f + Random.value, 0);
            else
                Rg.velocity = new Vector3(-(2f + Random.value * 4.5f), 5.5f + Random.value, 0);
        }
    }
}
