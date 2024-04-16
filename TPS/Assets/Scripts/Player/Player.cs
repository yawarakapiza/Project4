using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // �ʏ�̈ړ����x
    public float rotationSpeed = 10f; // �ʏ�̌����̕ύX���x
    protected Rigidbody rb; // Rigidbody �R���|�[�l���g�̎Q��
    //private bool isBallMode = false; // Ball���[�h���ǂ����̃t���O

    protected virtual void Start()
    {
        // Rigidbody �R���|�[�l���g���擾
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {

        // �L�[���͂��擾���Ēʏ�̈ړ��x�N�g�����v�Z
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // �ʏ�̈ړ������ɑ��x��������
        rb.velocity = moveDirection * moveSpeed;

        // �ړ�����������ꍇ�ɂ̂݌�����ύX����
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // �L�[�������ꂽ�ꍇ�A�����ɒ�~����
            rb.velocity = Vector3.zero;
        }
    }

}