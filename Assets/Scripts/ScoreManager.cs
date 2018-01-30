using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text m_score;
    public Transform m_player;

    // Use this for initialization
    void Start () {
        m_height = 0;
        m_bestScore = PlayerPrefs.GetInt("ScoreMax", 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (m_player.position.y > m_height) m_height = m_player.position.y;
        m_score.text = "Score : " + (int)m_height + " - Best Score : " + m_bestScore;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("ScoreMax", (int)m_height);
    }

    private float m_height;
    private int m_bestScore;
}
