using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // 弾の速さ
    public int damage = 1; // 弾のダメージ量

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        // 弾を前方に移動
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // 弾がEnemyに当たった場合
        if (other.CompareTag("Enemy"))
        {
            // Enemyにダメージを与える
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                Debug.Log(damage);
                enemyController.TakeDamage(damage);
            }

            // 弾を消滅させる
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Destroy(gameObject, 2f);
    }
}
