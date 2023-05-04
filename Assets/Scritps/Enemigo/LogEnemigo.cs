using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogEnemigo : MonoBehaviour

{

    public float moveSpeed;
    public float checkRadius;
    public float attackRadius;
    public bool rotacion;
    public LayerMask player;    //donde está el jugador

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 mov;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        anim.SetBool("Moviendo", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, player);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, player);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        mov = dir;

        if (rotacion)
        {
            anim.SetFloat("X", dir.x);
            anim.SetFloat("Y", dir.y);
        }
    }

    private void FixedUpdate()
    {
        if(isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(mov);
        }
        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * moveSpeed * Time.deltaTime));
    }
}
