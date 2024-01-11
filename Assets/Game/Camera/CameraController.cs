using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;  // プレイヤーとカメラの相対位置
    public float smoothTime = 0.3f;  // カメラがプレイヤーを追跡する際のスムーズさの調整用パラメータ
    private Vector3 velocity = Vector3.zero;  // カメラ移動時の速度ベクトル
    
    // Use this for initialization
    void Start()
    {

        player = GameObject.Find("Player");//Playerは必要に応じて変更する

        // MainCameraとplayerとの位置関係（方向＋距離）を求めて変数offsetに入れる
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Startで求めたプレイヤーとの位置関係を常にキープするようにカメラを動かす
        transform.position = player.transform.position + offset;
    }

}
