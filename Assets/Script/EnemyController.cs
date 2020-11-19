using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    ///

    ///
    [SerializeField] private float radiusRange = 6f;
    [SerializeField] private float rangeHitEnemy = 3f;
    private Quaternion rotationEnemy;
    [SerializeField] private bool hitPlayer;
    [SerializeField] private bool followPlayer;
    private bool waitFollow = false;
    public float timer = 3f;
    [SerializeField] private Vector2 lastPositionPlayer;
    [SerializeField] private LayerMask mask;
    [SerializeField] private Transform respawn;





    public Transform player;
    public Vector2 enemy;


    ///Componentes
    Rigidbody2D rb;

    ///
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        EnemyRunTarget();
        RandomWalk();
    }

   
    private void EnemyRunTarget()
    {

        //hitPlayer = Physics2D.Raycast(transform.position, -transform.right, rangeHitEnemy, mask);
        followPlayer = Physics2D.OverlapCircle(transform.position, radiusRange, mask);
    }
    private void RandomWalk()
    {
        if (followPlayer)
        {
            lastPositionPlayer = player.position;
            Vector2 cu = new Vector2(player.position.x > 0 ? 1 : -1, rb.velocity.y).normalized ;
            rb.velocity = cu;
            Debug.Log(cu.x);
        }
        

    }

}
