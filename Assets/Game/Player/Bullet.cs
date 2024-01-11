using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // ’e‚Ì‘¬‚³
    public int damage = 1; // ’e‚Ìƒ_ƒ[ƒW—Ê

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        // ’e‚ğ‘O•û‚ÉˆÚ“®
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // ’e‚ªEnemy‚É“–‚½‚Á‚½ê‡
        if (other.CompareTag("Enemy"))
        {
            // Enemy‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                Debug.Log(damage);
                enemyController.TakeDamage(damage);
            }

            // ’e‚ğÁ–Å‚³‚¹‚é
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Destroy(gameObject, 2f);
    }
}
