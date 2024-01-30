using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{

    public float speed = 5;
    public float attackingDistance = 1;
    public Vector3 direction;

    private Animator animatorEnemy;
    private Rigidbody rigidBodyEnemy;
    private Transform target;

    public bool isFollowingTarget;
    public bool isAttackingTarget;
    public float chasingPlayer = 0.01f;

    public float currentAttackingTime;
    public float maxAttackingTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        isFollowingTarget = true;
        currentAttackingTime = maxAttackingTime;
        animatorEnemy = GetComponentInChildren<Animator>();
        rigidBodyEnemy = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Update()
    {
        Attack();
    }

    // Update is called once per frame
    void FollowTarget()
    {
        if (!isFollowingTarget)
        {
            rigidBodyEnemy.isKinematic = true;
            return;
        }

        if(Vector3.Distance(transform.position, target.position) >= attackingDistance)
        {
            rigidBodyEnemy.isKinematic = false;
            direction = target.position - transform.position;
            direction.y = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 100);

            if(rigidBodyEnemy.velocity.sqrMagnitude != 0)
            {
                rigidBodyEnemy.velocity = transform.forward * speed;
                Debug.Log("igeorijgoeir");
                animatorEnemy.SetBool("Walk", true);

            }
        }
        else if (Vector3.Distance(transform.position, target.position) <= attackingDistance)
        {
            rigidBodyEnemy.isKinematic = false;
            rigidBodyEnemy.velocity = Vector3.zero;
            animatorEnemy.SetBool("Walk", false);
            isFollowingTarget = false;
            isAttackingTarget = true;
        }
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    void Attack()
    {
        if (!isAttackingTarget)
        {
            return;
        }

        currentAttackingTime += Time.deltaTime;

        if(currentAttackingTime > maxAttackingTime)
        {
            EnemyAttack(Random.Range(1, 6));
            currentAttackingTime = 0f;
        }

        if(Vector3.Distance(transform.position, target.position) > attackingDistance + chasingPlayer)
        {
            isAttackingTarget = false;
            isFollowingTarget = true;
        }
    }

    public void EnemyAttack(int attack)
    {
        if(attack == 1)
        {
            animatorEnemy.SetTrigger("Attack1");
        }

        if(attack == 2)
        {
            animatorEnemy.SetTrigger("Attack2");
        }

        if(attack == 3)
        {
            animatorEnemy.SetTrigger("Attack3");
        }

        if (attack == 4)
        {
            animatorEnemy.SetTrigger("Attack4");
        }

        if (attack == 5)
        {
            animatorEnemy.SetTrigger("Attack5");
        }

        if (attack == 6)
        {
            animatorEnemy.SetTrigger("Attack6");
        }
    }
}
