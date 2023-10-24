using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFX : MonoBehaviour
{
    void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
