using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletSpeed = 10f; // �e�̑���
    public int damage = 1; // �e�̃_���[�W��
    public GameObject bulletPrefab; // Inspector��Bullet��Prefab�����蓖�Ă邽�߂̕ϐ�

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Space�L�[�������ꂽ���̏���
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // Bullet�𐶐�
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // Rigidbody���A�^�b�`
        Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = transform.forward * bulletSpeed;
        }
    }
}