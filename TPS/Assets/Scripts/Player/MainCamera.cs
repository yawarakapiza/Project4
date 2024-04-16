using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject[] targetObjects;   // �ǐՑΏۂ̃I�u�W�F�N�g�̔z��
    public Vector3 offset;              // �J�����Ƃ̑��΋���
    private int currentTargetIndex = 0;  // ���݂̒ǐՑΏۂ̃C���f�b�N�X

    // Start is called before the first frame update
    void Start()
    {
        if (targetObjects != null && targetObjects.Length > 0)
        {
            SetTarget(currentTargetIndex); // �����̒ǐՑΏۂ�ݒ�
        }
        else
        {
            Debug.LogWarning("Target objects array is null or empty!");
        }
    }

    // LateUpdate is called once per frame, after all Update calls
    void LateUpdate()
    {
        if (targetObjects != null && targetObjects.Length > 0 && targetObjects[currentTargetIndex] != null)
        {
            // �J�����̈ʒu��ݒ肵���I�u�W�F�N�g�̈ʒu�ɃI�t�Z�b�g���������ʒu�ɂ���
            transform.position = targetObjects[currentTargetIndex].transform.position + offset;
        }
    }

    // �w�肵���C���f�b�N�X�̒ǐՑΏۂ�ݒ肷��
    public void SetTargetIndex(int index)
    {
        if (index >= 0 && index < targetObjects.Length)
        {
            SetTarget(index);
        }
    }

    // �ǐՑΏۂ�؂�ւ���
    private void SetTarget(int index)
    {
        if (index >= 0 && index < targetObjects.Length)
        {
            currentTargetIndex = index;
        }
    }
}
