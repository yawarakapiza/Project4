using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Player
{
    public GameObject BulletPrefab; // ��������e�I�u�W�F�N�g�̃v���n�u
    public GameObject bulletSpawnPoint; // �e�𐶐�����ʒu�̃I�u�W�F�N�g
    public float fireRate = 0.5f; // ���˃��[�g�i1�b������̔��ː��j
    public float bulletSpeed = 10f; // ���˃��[�g�i1�b������̔��ː��j
    public Vector3 mouseOffset = new Vector3(20, 20, 0); // �}�E�X�ʒu����̃I�t�Z�b�g
    public float spreadAngle = 5f; // ���˂̂΂���p�x

    private float nextFireTime = 0f; // ���ɔ��ˉ\�Ȏ���

    protected override void Update()
    {
        // Gun�I�u�W�F�N�g�̕������X�V����
        Vector3 mousePosition = Input.mousePosition + mouseOffset;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));
        worldMousePosition.y = transform.position.y;
        transform.rotation = Quaternion.LookRotation(worldMousePosition - transform.position);

        // �}�E�X�̍��{�^����������Ă��āA���ɔ��ˉ\�Ȏ��ԂɂȂ��Ă��邩���m�F
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Vector3 spawnPoint = bulletSpawnPoint.transform.position;

            // ���˕����Ƀ����_���ȉ�]��������
            Quaternion spreadRotation = Quaternion.Euler(Random.Range(-spreadAngle, spreadAngle), Random.Range(-spreadAngle, spreadAngle), 0);
            Quaternion bulletRotation = transform.rotation * spreadRotation;

            // �e�𐶐�
            GameObject bullet = Instantiate(BulletPrefab, spawnPoint, bulletRotation);

            // Rigidbody�R���|�[�l���g���擾���Ēe�𔭎�
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed; // �K�؂ȑ��x��ݒ�
            }

            // ���̔��ˉ\���Ԃ�ݒ�
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
