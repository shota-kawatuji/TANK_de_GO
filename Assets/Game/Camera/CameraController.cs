using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;  // �v���C���[�ƃJ�����̑��Έʒu
    public float smoothTime = 0.3f;  // �J�������v���C���[��ǐՂ���ۂ̃X���[�Y���̒����p�p�����[�^
    private Vector3 velocity = Vector3.zero;  // �J�����ړ����̑��x�x�N�g��
    
    // Use this for initialization
    void Start()
    {

        player = GameObject.Find("Player");//Player�͕K�v�ɉ����ĕύX����

        // MainCamera��player�Ƃ̈ʒu�֌W�i�����{�����j�����߂ĕϐ�offset�ɓ����
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Start�ŋ��߂��v���C���[�Ƃ̈ʒu�֌W����ɃL�[�v����悤�ɃJ�����𓮂���
        transform.position = player.transform.position + offset;
    }

}
