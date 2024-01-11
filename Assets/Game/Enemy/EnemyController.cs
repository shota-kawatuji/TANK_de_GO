using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int enemyHp; // Enemyのヒットポイント
    [SerializeField] float moveSpeed; // 移動速度
    [SerializeField] Transform player; // プレイヤーのTransform

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
        // プレイヤーの方向へのベクトルを計算
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // プレイヤーの方向に移動
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        enemyHp -= damage;
        Debug.Log(enemyHp);
        Debug.Log("当たった");

        if (enemyHp <= 0)
        {
            Die(); // HPが0以下になったらDieメソッドを呼ぶ
        }
    }

    public event Action OnEnemyDied; // Enemyが死んだときに通知するイベント
    public void Die()
    {
        Destroy(gameObject);

        // OnEnemyDiedイベントを発火して、EnemyManagerに通知
        OnEnemyDied?.Invoke();

        Debug.Log("倒した");
    }
}
