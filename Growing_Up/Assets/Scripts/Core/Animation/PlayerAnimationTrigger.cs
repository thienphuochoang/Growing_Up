using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _youLostWindow;
    private Player _player => GetComponentInParent<Player>();

    private void TriggerAnimation()
    {
        _player.TriggerAnimation();
    }

    private void TriggerAttackAnimation()
    {
        Collider2D[] colliders =
            Physics2D.OverlapCircleAll(_player.attackCheck.position, _player.attackCheckRadius);
        foreach (Collider2D hitObj in colliders)
        {
            
            if (hitObj.GetComponent<Enemy>() != null)
            {
                hitObj.GetComponent<Enemy>().Die();
                GameManager.Instance.EnemyKillCount--;
            }
            else if (hitObj.GetComponent<BreakableObject>() != null && GameManager.Instance.canBreakObjects)
            {
                hitObj.GetComponent<BreakableObject>().Break();
            }
        }
    }

    private void TriggerYouLostWindow()
    {
        _youLostWindow.SetActive(true);
        Time.timeScale = 0;
    }
}
