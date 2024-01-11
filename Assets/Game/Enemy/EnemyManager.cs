using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnInterval;
    [SerializeField] float spawnRadius;
    [SerializeField] int enemyMax; // Enemyのゲーム中の最大生成数
    [SerializeField] int maxSpawn; // Enemyのウェーブ中の最大出現数
    private int currentEnemyCount; // Enemyの現在のスポーン数
    private int enemyKills; // Enemyの合計キル数

    void Start()
    {
        // 一定間隔でSpawnEnemyメソッドを呼び出す
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void Update()
    {
        // enemyMaxがenemyKillsより大きく、currentEnemyCountがmaxSpawnより小さい場合にSpawnEnemyを呼び出す
        if (enemyMax > enemyKills && currentEnemyCount < maxSpawn)
        {
            CancelInvoke("SpawnEnemy");
        }

        // enemyKillsがenemyMaxを上回った場合シーンチェンジ
        if (enemyKills > enemyMax)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }

    void SpawnEnemy()
    {
        // ランダムな位置にEnemyを生成
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        randomPosition.y = 20.0f;

        // EnemyPrefabから新しいEnemyを生成
        GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        // 生成されたEnemyをEnemyManagerの子オブジェクトに設定する
        newEnemy.transform.parent = transform;

        // 生成されたEnemyにEnemyControllerスクリプトをアタッチする
        EnemyController enemyController = newEnemy.AddComponent<EnemyController>();

        // Enemyが死んだときに通知されるイベントに対するリスナーを設定
        enemyController.OnEnemyDied += HandleEnemyDied;

        // 現在のEnemyの数をインクリメント
        currentEnemyCount++;
    }

    void HandleEnemyDied()
    {
        // Enemyが死んだときに呼ばれるメソッド
        enemyKills++;
        currentEnemyCount--;
        Debug.Log(enemyKills);
    }
}
