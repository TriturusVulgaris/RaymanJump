using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

    public Movement m_player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_player.Jump();
        //collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 350));
        //Jump(350);

        //m_collider2d.isTrigger = false;
        //m_player.m_newJump = true;
    }
}
