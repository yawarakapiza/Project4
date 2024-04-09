using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // �ړ����x
    public float rotationSpeed = 10f; // �����̕ύX���x

    private Rigidbody rb; // Rigidbody �R���|�[�l���g�̎Q��

    void Start()
    {
        // Rigidbody �R���|�[�l���g���擾
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // �L�[���͂��擾���Ĉړ��x�N�g�����v�Z
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // �ړ��������v�Z
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // �ړ�����������ꍇ�ɂ̂݌�����ύX����
        if (moveDirection != Vector3.zero)
        {
            // �ڕW�̌������v�Z
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            // ���݂̌�������ڕW�̌����Ɍ����ĕ�Ԃ���
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // �L�[�������ꂽ�ꍇ�A�����ɒ�~����
            rb.velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        // �L�[���͂��擾���Ĉړ��x�N�g�����v�Z
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // �ړ��������v�Z
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // �ړ������ɑ��x��������
        rb.velocity = moveDirection * moveSpeed;
    }
}
