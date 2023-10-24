using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadground : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>() != null)
        {
            col.GetComponent<Player>().Die();
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
}
