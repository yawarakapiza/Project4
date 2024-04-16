using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    public GameObject[] targetObjects; // �Ώۂ̃I�u�W�F�N�g���i�[����z��
    private Vector3[] objectPositions; // �Ώۂ̃I�u�W�F�N�g�̏����ʒu���i�[����z��
    //���W
    int x = 0;

    public bool isModeChange = false; // ���[�h�ύX�t���O

    public float cooldownTime = 1.0f; // �N�[���_�E������
    private float cooldownTimer = 0.0f; // �N�[���_�E���^�C�}�[

    void Start()
    {
        // �Ώۂ̃I�u�W�F�N�g�̏����ʒu��ۑ����邽�߂̔z���������
        objectPositions = new Vector3[targetObjects.Length];

        // �����ʒu��ۑ�
        for (int i = 0; i < targetObjects.Length; i++)
        {
            objectPositions[i] = targetObjects[i].transform.position;
        }
    }

    void Update()
    {
        // �N�[���_�E�����͏������Ȃ�
        if (cooldownTimer > 0.0f)
        {
            cooldownTimer -= Time.deltaTime;
            return;
        }

        // �I�u�W�F�N�g�̈ʒu���ς������X�V
        for (int i = 0; i < targetObjects.Length; i++)
        {
            if (targetObjects[i].transform.position != objectPositions[i])
            {
                objectPositions[i] = targetObjects[i].transform.position;
                x = i;
                //Debug.Log("Object " + targetObjects[i].name + " position updated: " + objectPositions[i]);
            }
        }

        // �X�y�[�X�L�[�������ꂽ�烂�[�h�ύX�t���O��؂�ւ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isModeChange = !isModeChange;
            Debug.Log("Mode change: " + isModeChange);

            // ���[�h���ύX���ꂽ��ǐՑΏۂ�؂�ւ���
            if (isModeChange)
            {
                // Element 0 ���A�N�e�B�u�ɂ��AElement 1 ���A�N�e�B�u�ɂ���
                if (targetObjects.Length > 1 && targetObjects[0] != null && targetObjects[1] != null)
                {
                    // Element 0 ���A�N�e�B�u�ɂ��AElement 1 ���A�N�e�B�u�ɂ��ď����ʒu�Ɉړ�������
                    targetObjects[0].SetActive(false);
                    targetObjects[1].SetActive(true);
                    targetObjects[1].transform.position = objectPositions[x];
                }
            }
            else
            {
                // Element 1 ���A�N�e�B�u�ɂ��AElement 0 ���A�N�e�B�u�ɂ���
                if (targetObjects.Length > 1 && targetObjects[0] != null && targetObjects[1] != null)
                {
                    // Element 1 ���A�N�e�B�u�ɂ��AElement 0 ���A�N�e�B�u�ɂ��ď����ʒu�Ɉړ�������
                    targetObjects[1].SetActive(false);
                    targetObjects[0].SetActive(true);
                    targetObjects[0].transform.position = objectPositions[x];
                }
            }

            // �N�[���_�E�����J�n����
            cooldownTimer = cooldownTime;
        }
    }
}
