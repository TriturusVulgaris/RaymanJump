using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour {

    public Transform m_player;
    public Transform m_camera;
    public Text m_gameOver;
    public Button m_tryAgain;
    public ScoreManager m_scoreManager;

    // Use this for initialization
    void Start () {
        m_scoreManager = GetComponent<ScoreManager>();
        m_tryAgain.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if(m_camera.position.y - m_player.position.y > 11)
        {
            m_gameOver.enabled = true;
            m_tryAgain.gameObject.SetActive(true);
            Debug.Log("DED");
            m_player.gameObject.SetActive(false);
            m_scoreManager.SaveScore();
        }
	}
}
