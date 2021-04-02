using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int ComboCooldown = 1;

    public int attackDamage = 40;

    private int comboCounter = 0;
    public int maxComboLimit = 2;

    public float attackRate = 2f;
    public float comboDelay = 1f;

    bool attacking = false;
    bool canAttackAgain = true;

    void Update()
    {
        if (canAttackAgain)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack();
            }

            if (Input.GetKeyUp(KeyCode.K))
            {
                attacking = false;
            }
        }
    }

    public void CanAttackAgainTrue()
    {
        canAttackAgain = true;
    }

    public void CanAttackAgainFalse()
    {
        canAttackAgain = false;
    }

    void ResetCombo()
    {       
        comboCounter = 0;
        animator.SetInteger("Combo", comboCounter);
    }

    IEnumerator ComboTimer(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetCombo();
    }

    void Attack()
    {
        attacking = true;
        //Play attack anim.
        comboCounter++;
        animator.SetTrigger("Attack");
        animator.SetInteger("Combo", comboCounter);

        if (animator.GetInteger("Combo") >= maxComboLimit)
        {
            StartCoroutine(ComboTimer(0.5f));
        }
        else
        {
            StartCoroutine(ComboTimer(comboDelay));
        }

        //Detect enemes in range.
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them.
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(20);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
