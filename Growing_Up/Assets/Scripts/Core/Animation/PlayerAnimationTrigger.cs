using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Player _player => GetComponentInParent<Player>();

    private void TriggerAnimation()
    {
        _player.TriggerAnimation();
    }
}
