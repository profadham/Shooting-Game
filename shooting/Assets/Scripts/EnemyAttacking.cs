using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    private Animator animator;
    private playerHealth playerHealth;
    private bool attackingActive = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        attackingActive = true;
        playerHealth = FindObjectOfType<playerHealth>();
    }
    public virtual void Attack()
    {
        if (attackingActive)
        {
            return;
        }
        attackingActive = true;
        StartCoroutine(AttackCoroutine());
    }

    public virtual void stopAttack()
    {
        attackingActive = false;
    }

    private IEnumerator AttackCoroutine()
    {
        animator.SetBool("Attack", true);

        while (attackingActive)
        {
            if (playerHealth)
            {
                playerHealth.DeacreaseHealth(10);
                
            }

            yield return (new WaitForSeconds(2));

        }
    }
}
