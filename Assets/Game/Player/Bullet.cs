using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f; // �e�̑���
    public int damage = 1; // �e�̃_���[�W��

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        // �e��O���Ɉړ�
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // �e��Enemy�ɓ��������ꍇ
        if (other.CompareTag("Enemy"))
        {
            // Enemy�Ƀ_���[�W��^����
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                Debug.Log(damage);
                enemyController.TakeDamage(damage);
            }

            // �e�����ł�����
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Destroy(gameObject, 2f);
    }
}
