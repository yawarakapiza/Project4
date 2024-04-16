using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Player
{
    public GameObject BulletPrefab; // ��������e�I�u�W�F�N�g�̃v���n�u
    public GameObject bulletSpawnPoint; // �e�𐶐�����ʒu�̃I�u�W�F�N�g
    public float fireRate = 0.5f; // ���˃��[�g�i1�b������̔��ː��j
    public Vector3 mouseOffset = new Vector3(20, 20, 0); // �}�E�X�ʒu����̃I�t�Z�b�g

    private float nextFireTime = 0f; // ���ɔ��ˉ\�Ȏ���

    protected override void Update()
    {
        //base.Update();

        // Gun�I�u�W�F�N�g�̕������X�V����
        // �}�E�X�̈ʒu����I�t�Z�b�g���������ʒu���擾
        Vector3 mousePosition = Input.mousePosition + mouseOffset;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));
        worldMousePosition.y = transform.position.y;

        // �}�E�X�̕���������
        transform.rotation = Quaternion.LookRotation(worldMousePosition - transform.position);

        // �}�E�X�̍��{�^����������Ă��āA���ɔ��ˉ\�Ȏ��ԂɂȂ��Ă��邩���m�F
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            // �e�𐶐�����ʒu���擾
            Vector3 spawnPoint = bulletSpawnPoint.transform.position;

            // �e�𐶐�
            GameObject bullet = Instantiate(BulletPrefab, spawnPoint, bulletSpawnPoint.transform.rotation);

            // Rigidbody�R���|�[�l���g���擾���Ēe�𔭎�
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                // �e�𔭎˕����ɔ�΂�
                bulletRigidbody.velocity = bulletSpawnPoint.transform.forward * 10f; // �K�؂ȑ��x��ݒ�
            }

            // ���̔��ˉ\���Ԃ�ݒ�
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
