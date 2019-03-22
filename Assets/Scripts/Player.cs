using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    HUD PlayerHUD;
    AudioSource Au;
    public float Speed;
    public int Hp = 3;
    // Use this for initialization
    void Start()
    {
        Au = GetComponent<AudioSource>();
        PlayerHUD = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        PlayerHUD.SetHp(Hp);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") && transform.position.x < 7.3f)
        {
            transform.Translate(Speed, 0f, 0f);
        }
        else
        if (Input.GetKey("a") && transform.position.x > -7.3f)
        {
            transform.Translate(-Speed, 0f, 0f);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
            Au.Play();
    }

    public void RemoveHp()
    {
        Hp--;
        PlayerHUD.SetHp(Hp);
    }

    public void AddHp()
    {
        GameObject.FindGameObjectWithTag("HpBar").GetComponent<AudioSource>().Play();
        Hp++;
        PlayerHUD.SetHp(Hp);
    }
}
