using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletSpeed = 10f; // 弾の速さ
    public int damage = 1; // 弾のダメージ量
    public GameObject bulletPrefab; // InspectorでBulletのPrefabを割り当てるための変数

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Spaceキーが押された時の処理
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // Bulletを生成
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // Rigidbodyをアタッチ
        Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = transform.forward * bulletSpeed;
        }
    }
}