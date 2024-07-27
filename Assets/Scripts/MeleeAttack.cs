using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Animator animator; 
    public float attackCooldown = 1f;

    private bool canAttack = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            animator.SetTrigger("Attack");

            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
