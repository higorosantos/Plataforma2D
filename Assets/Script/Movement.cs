using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Ground Checker")]
    [SerializeField]Transform groundChecker;
    [SerializeField]float radius;
    [SerializeField] LayerMask layer;
    [SerializeField] bool isGround;


    Rigidbody2D rg;
    BoxCollider2D bc;
    SpriteRenderer sr;
    

    [Header("Status")]

    [Range(0,15)]
    [SerializeField]float walkSpeed;
    [Range(16, 20)]
    [SerializeField]float runSpeed = 16;
    //[Range(0, 5)]
    [SerializeField]float jumpForce;
    

    float horizontal;
    Vector2 direction;
    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        
    }
    
    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Flip();
        Jump();
        
    }

    void FixedUpdate()
    {
        Walk();
        GroundChecker();
    }
    void Walk() {
        direction = new Vector2(horizontal * walkSpeed, rg.velocity.y);
        rg.velocity = direction;
        //Debug.Log("Direção sem normalize: " + direction);
        //Debug.Log(direction.x);
    }

    void Flip() {

        if(direction.x < 0 && !sr.flipX || direction.x > 0 && sr.flipX)
        {
            sr.flipX = !sr.flipX;
        }

    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rg.velocity = new Vector2(rg.velocity.x,0);
            rg.AddForce(new Vector2 (0,jumpForce),ForceMode2D.Impulse);
            //Debug.Log("JUMP");
        }
    }
    void GroundChecker()
    {
        isGround = Physics2D.OverlapCircle(groundChecker.position,radius, layer); 
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(groundChecker.position, radius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
