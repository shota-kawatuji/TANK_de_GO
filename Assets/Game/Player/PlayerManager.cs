using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerHp;
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        movementInputValue = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void Turn()
    {
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    // ダメージを受ける処理
    public void TakeDamage(int damageAmount)
    {
        playerHp -= damageAmount;
        Debug.Log("接触");
        // プレイヤーのHPが0以下になったら消滅
        if (playerHp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Player destroyed");
        }
    }

    // 当たり判定
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがEnemyであればダメージを受ける
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int damageAmount = 1;
            TakeDamage(damageAmount);
        }
    }
}
