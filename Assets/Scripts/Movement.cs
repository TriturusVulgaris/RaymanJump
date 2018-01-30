using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    #region Public Members

    public Transform m_transform;
    [Range(1, 1500)]
    public int m_jumpImpulse;
    [Range(1, 10)]
    public float m_speed;
    public SpriteRenderer m_rfoot_rend;
    public SpriteRenderer m_rhand_rend;
    public SpriteRenderer m_lfoot_rend;
    public SpriteRenderer m_lhand_rend;


    #endregion

    #region Public void

    #endregion

    #region System

    void Awake()
    {
        m_transform = GetComponent<Transform>();
        m_rigidbody_2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }
	
	void Update()
    {
        GetInput();
        MoveSprite();
        UpdateAnimator();
        FlipSprite();
    }

    #endregion

    #region Class Methods

    void GetInput()
    {
        //m_movement.y = Input.GetAxisRaw("Vertical");
#if UNITY_ANDROID
        m_movement.x = Input.acceleration.x;
        if(Input.touches.Length > 0)
        {
            Jump();
        }
#elif UNITY_EDITOR || UNITY_WEBGK
        m_movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else
        {
            //m_animator.SetBool("Jump", false);
        }
#endif
    }


    void UpdateAnimator()
    {
        //m_animator.SetFloat("SpeedVertical", m_movement.y);
        m_animator.SetFloat("SpeedHorizontal", m_movement.x);

        if (m_bufmovement.x != m_movement.x)
        {
            Debug.Log("Flip");
            FlipSprite();
        }
        m_bufmovement = m_movement;
    }

    public void Jump()
    {
        Debug.Log("Jump");
        m_animator.SetBool("Jump", true);
        m_rigidbody_2D.velocity = Vector2.zero;
        m_rigidbody_2D.AddForce(new Vector2(0, m_jumpImpulse), ForceMode2D.Impulse);
    }
    void FlipSprite()
    {
        if (m_movement.x != 0f)
        {
            m_transform.localScale = new Vector3(Mathf.Sign(m_movement.x)*.5f, .5f, .5f);
            if (m_movement.x >= 0.1f)
            {
                m_rhand_rend.sortingOrder = -90;
                m_lhand_rend.sortingOrder = 20;
                m_rfoot_rend.sortingOrder = -50;
                m_lfoot_rend.sortingOrder = 10;
            }
            else
            {
                m_rhand_rend.sortingOrder = 90;
                m_lhand_rend.sortingOrder = -20;
                m_rfoot_rend.sortingOrder = 50;
                m_lfoot_rend.sortingOrder = -10;
            }
        }
    }

    void MoveSprite()
    {
        m_temporaryPosition = m_transform.position;
        m_temporaryPosition.x += m_movement.x * m_speed * Time.deltaTime;
       // m_temporaryPosition.y += m_movement.y * m_speed * Time.deltaTime;
        m_transform.position = m_temporaryPosition;
    }

#endregion

#region Tools Debug And Utility

#endregion

#region Private an Protected Members

    private SpriteRenderer m_spriteRenderer;
    private Rigidbody2D m_rigidbody_2D;
    private Vector2 m_movement;
    private Vector2 m_bufmovement;
    private bool m_jump;
    private Animator m_animator;
    private Vector3 m_temporaryPosition;

#endregion
}