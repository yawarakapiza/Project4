using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    void Update()
    {
        // �}�E�X�̈ʒu���擾
        Vector3 mousePosition = Input.mousePosition;

        // �J��������}�E�X�̈ʒu�܂ł̃x�N�g�����擾
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));

        // y���̈ʒu��Gun�I�u�W�F�N�g��y���W�ɌŒ�
        worldMousePosition.y = transform.position.y;

        // Gun�I�u�W�F�N�g���J�[�\���̕����������悤�ɂ���
        transform.LookAt(worldMousePosition, Vector3.up);
    }
}
