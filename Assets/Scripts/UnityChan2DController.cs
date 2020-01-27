using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class UnityChan2DController : MonoBehaviour
{
    public float speed = 0f;
    public float maxSpeed = 40f;
    public float jumpPower = 10f;
    public LayerMask whatIsGround;
    /*
    public Text overText;
    public Text overText2;
    public Text overText3;
    */
    public Text pointsText;
    private Animator m_animator;
    private BoxCollider2D m_boxcollier2D;
    private Rigidbody2D m_rigidbody2D;
    private bool m_isGround;
    private const float m_centerY = 1.5f;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_boxcollier2D = GetComponent<BoxCollider2D>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        
    }


    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        Move(x, jump);

        if (Input.GetKey(KeyCode.A))
        {
            speed = -20f;
            transform.rotation= Quaternion.Euler(0.0f, 180f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speed = 20f;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else speed = 0f;
        Vector2 pos = transform.position;
        Vector2 groundCheck = new Vector2(pos.x, pos.y - (m_centerY * transform.localScale.y));
        Vector2 groundArea = new Vector2(m_boxcollier2D.size.x * 0.49f, 0.05f);

        m_isGround = Physics2D.OverlapArea(groundCheck + groundArea, groundCheck - groundArea, whatIsGround);
        m_animator.SetBool("isGround", m_isGround);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Over"))
        {
            maxSpeed = 0;
            jumpPower = 0;
            m_animator.Play(m_isGround ? "Damage" : "AirDamage");
            /*
            overText.text = "Game Over";
            overText2.text="あなたのポイントは" + pointsText.text;
            overText3.text = "Press X to Title";
            */
        }

    }
    void Move(float move, bool jump)
    {
        m_rigidbody2D.velocity = new Vector2(speed, m_rigidbody2D.velocity.y);
        
        m_animator.SetFloat("Horizontal", speed);
        m_animator.SetFloat("Vertical", m_rigidbody2D.velocity.y);
        m_animator.SetBool("isGround", m_isGround);

        if (jump && m_isGround)
        {
            m_animator.SetTrigger("Jump");
            SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
            m_rigidbody2D.AddForce(Vector2.up * jumpPower);
        }
    }


}
