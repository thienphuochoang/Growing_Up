using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private string targetLayerName = "Player";
    private Rigidbody2D _rb;
    private Animator _animator;
    private Enemy _enemy;
    private Vector3 _playerPosition;


    public float firingAngle = 45.0f;

    private void Start()
    {
        _playerPosition = PlayerManager.Instance.player.transform.position;
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        float target_Distance = Vector3.Distance(transform.position, _playerPosition);
        Vector2 direction = (_playerPosition - transform.position).normalized;
        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / (Physics2D.gravity.y * -1));

        // Extract the X Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        Vector2 vel = new Vector2(Vx * direction.x, Vy);
        
        _rb.AddForce(vel,ForceMode2D.Impulse);
    }
    public void SetupProjectile(Vector3 playerPosition)
    {
        _playerPosition = playerPosition;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer(targetLayerName))
        {
            HitCollision();
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            HitCollision();
        }
    }

    private void HitCollision()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        _rb.isKinematic = true;
        _rb.constraints = RigidbodyConstraints2D.FreezeAll;
        _animator.SetTrigger("Explode");
    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
