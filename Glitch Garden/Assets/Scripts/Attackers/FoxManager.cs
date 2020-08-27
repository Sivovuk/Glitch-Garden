using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxManager : Attackers
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _target = collision.gameObject;
            _movementController.SetWait();
            _animator.SetBool("isAttacking", true);
        }
        else if (collision.CompareTag("Gravestone"))
        {
            JumpOver();
        }
    }

    private void JumpOver()
    {
        _movementController.SetWait();
        _animator.SetTrigger("isJump");
        GetComponent<MovementController>().SetRunningSpeed();
        _movementController.SetWalk();
    }
}
