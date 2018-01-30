using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlatformSpawn : MonoBehaviour {

    public Transform m_playerTransform;

    // Use this for initialization
    void Start () {
        m_transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_transform.position.y - m_playerTransform.position.y < -10)
        {
            Random rnd = new Random();
            float x = rnd.Next(-50, 50)*.1f;
            Debug.Log(x);
            m_transform.position = new Vector2(x, m_playerTransform.position.y + 20 + m_interval);
            m_interval += 0.5f;
        }
        
	}

    private Transform m_transform;
    private float m_interval = 0;

}
