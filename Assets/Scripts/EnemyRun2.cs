using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun2 : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 2f;

    Transform player;
    Rigidbody2D rb;
    Vector2 target;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.GetComponent<Bandit>().Flip();
        target = new Vector2(player.position.x, rb.position.y);
        Vector2 nowPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(nowPos);

        float ramdomAttack = Random.Range(-3f, 5f);

        if (Vector2.Distance(player.position, rb.position) < attackRange && ramdomAttack <= 1f)
        {
            animator.SetTrigger("Attack");
        }
        else if (Vector2.Distance(player.position, rb.position) < attackRange && ramdomAttack > 1)
        {
            animator.SetTrigger("Attack2");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}