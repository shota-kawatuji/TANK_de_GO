using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnInterval;
    [SerializeField] float spawnRadius;
    [SerializeField] int enemyMax; // Enemy�̃Q�[�����̍ő吶����
    [SerializeField] int maxSpawn; // Enemy�̃E�F�[�u���̍ő�o����
    private int currentEnemyCount; // Enemy�̌��݂̃X�|�[����
    private int enemyKills; // Enemy�̍��v�L����

    void Start()
    {
        // ���Ԋu��SpawnEnemy���\�b�h���Ăяo��
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void Update()
    {
        // enemyMax��enemyKills���傫���AcurrentEnemyCount��maxSpawn��菬�����ꍇ��SpawnEnemy���Ăяo��
        if (enemyMax > enemyKills && currentEnemyCount < maxSpawn)
        {
            CancelInvoke("SpawnEnemy");
        }

        // enemyKills��enemyMax���������ꍇ�V�[���`�F���W
        if (enemyKills > enemyMax)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }

    void SpawnEnemy()
    {
        // �����_���Ȉʒu��Enemy�𐶐�
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        randomPosition.y = 20.0f;

        // EnemyPrefab����V����Enemy�𐶐�
        GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        // �������ꂽEnemy��EnemyManager�̎q�I�u�W�F�N�g�ɐݒ肷��
        newEnemy.transform.parent = transform;

        // �������ꂽEnemy��EnemyController�X�N���v�g���A�^�b�`����
        EnemyController enemyController = newEnemy.AddComponent<EnemyController>();

        // Enemy�����񂾂Ƃ��ɒʒm�����C�x���g�ɑ΂��郊�X�i�[��ݒ�
        enemyController.OnEnemyDied += HandleEnemyDied;

        // ���݂�Enemy�̐����C���N�������g
        currentEnemyCount++;
    }

    void HandleEnemyDied()
    {
        // Enemy�����񂾂Ƃ��ɌĂ΂�郁�\�b�h
        enemyKills++;
        currentEnemyCount--;
        Debug.Log(enemyKills);
    }
}
