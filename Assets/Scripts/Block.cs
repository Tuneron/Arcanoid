using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public int Hp;
    AudioSource Au;

    // Use this for initialization
    void Start()
    {
        Hp = 1;
        Au = GetComponent<AudioSource>();
        gameObject.layer = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        Au.Play();
        if (--Hp <= 0)
        {
            GetComponent<BoxCollider>().isTrigger = true;
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().AddScore(10);
            Destroy(this.gameObject, Au.clip.length);
        }
        else
            Hp--;
    }

    IEnumerator ReplayRoutine()
    {
        Au.Play();
        yield return new WaitForSeconds(Au.clip.length);
    }
}
