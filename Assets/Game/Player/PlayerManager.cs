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

    // �_���[�W���󂯂鏈��
    public void TakeDamage(int damageAmount)
    {
        playerHp -= damageAmount;
        Debug.Log("�ڐG");
        // �v���C���[��HP��0�ȉ��ɂȂ��������
        if (playerHp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Player destroyed");
        }
    }

    // �����蔻��
    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g��Enemy�ł���΃_���[�W���󂯂�
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int damageAmount = 1;
            TakeDamage(damageAmount);
        }
    }
}
