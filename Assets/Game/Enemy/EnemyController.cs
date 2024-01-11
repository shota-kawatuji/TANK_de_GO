using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int enemyHp; // Enemy�̃q�b�g�|�C���g
    [SerializeField] float moveSpeed; // �ړ����x
    [SerializeField] Transform player; // �v���C���[��Transform

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        // �v���C���[�̕����ւ̃x�N�g�����v�Z
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // �v���C���[�̕����Ɉړ�
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        enemyHp -= damage;
        Debug.Log(enemyHp);
        Debug.Log("��������");

        if (enemyHp <= 0)
        {
            Die(); // HP��0�ȉ��ɂȂ�����Die���\�b�h���Ă�
        }
    }

    public event Action OnEnemyDied; // Enemy�����񂾂Ƃ��ɒʒm����C�x���g
    public void Die()
    {
        Destroy(gameObject);

        // OnEnemyDied�C�x���g�𔭉΂��āAEnemyManager�ɒʒm
        OnEnemyDied?.Invoke();

        Debug.Log("�|����");
    }
}
