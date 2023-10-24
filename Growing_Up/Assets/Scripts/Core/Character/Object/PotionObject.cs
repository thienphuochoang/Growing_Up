using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionObject : MonoBehaviour
{
    [SerializeField]
    private GameObject pickupFXPrefab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            PlayerManager.Instance.player.AddPotion(1);
            Instantiate(pickupFXPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
