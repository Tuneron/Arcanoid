using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    // Use this for initialization

    AudioSource As;
	void Start () {
        As = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        As.Play();

        if (collision.gameObject.tag == "Ball" && (collision.gameObject.GetComponent<Rigidbody>().velocity.y < 1.4f
            && collision.gameObject.GetComponent<Rigidbody>().velocity.y > -1.4f))
            collision.gameObject.GetComponent<Rigidbody>().velocity =
                new Vector3(collision.gameObject.GetComponent<Rigidbody>().velocity.x, collision.gameObject.GetComponent<Rigidbody>().velocity.y * 2, 0);
    }
}
