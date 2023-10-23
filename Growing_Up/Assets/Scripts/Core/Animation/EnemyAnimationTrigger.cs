using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTrigger : MonoBehaviour
{
    private Enemy _enemy => GetComponentInParent<Enemy>();

    private void TriggerAnimation()
    {
        _enemy.TriggerAnimation();
    }

    private void TriggerAttackAnimation()
    {
        _enemy.TriggerAttackAnimation();
    }
}