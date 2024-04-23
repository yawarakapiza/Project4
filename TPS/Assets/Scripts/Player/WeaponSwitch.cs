using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] guns; // Gun�I�u�W�F�N�g�̔z��
    private int currentGunIndex = 0; // ���݃A�N�e�B�u��Gun�I�u�W�F�N�g�̃C���f�b�N�X

    void Start()
    {
        // ������Ԃōŏ��̏e�ȊO���A�N�e�B�u�ɂ���
        UpdateWeaponActiveState();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // �E�N���b�N�������ꂽ�������o�i0: ���N���b�N, 1: �E�N���b�N, 2: ���N���b�N�j
        {
            SwitchWeapon();
        }
    }

    void SwitchWeapon()
    {
        // ���݂̏e���A�N�e�B�u�ɂ���
        guns[currentGunIndex].SetActive(false);

        // ���̏e�̃C���f�b�N�X���v�Z����
        currentGunIndex = (currentGunIndex + 1) % guns.Length; // �z��̒����Ŋ������]�����邱�Ƃŏz������

        // �V�����e���A�N�e�B�u�ɂ���
        guns[currentGunIndex].SetActive(true);
    }

    // ���ׂĂ̏e���A�N�e�B�u�ɂ��A���ݑI������Ă���e�������A�N�e�B�u�ɂ���
    void UpdateWeaponActiveState()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
        guns[currentGunIndex].SetActive(true);
    }
}
