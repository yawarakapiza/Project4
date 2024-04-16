using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform[] waypoints; // �ړ���̋�̃I�u�W�F�N�g���i�[����z��
    public float moveSpeed = 5f; // �ړ����x
    public Collider moveAdaptiveArea; // �ړ��K���G���A�̃R���C�_�[
    public GameObject[] playerObjects; // �蓮�őI������Player�I�u�W�F�N�g�̔z��
    public float accelerationRate = 1.0f; // �ړ��J�n���̉����x
    public float decelerationRate = 1.0f; // ��~���̌����x

    private int currentWaypointIndex = 0; // ���݂̖ڕW�n�_�̃C���f�b�N�X
    private bool isMoving = false; // �ړ������ǂ����̃t���O
    private float currentSpeed = 0f; // ���݂̈ړ����x

    void Update()
    {
        // �蓮�őI�����ꂽPlayer�I�u�W�F�N�g���ړ��K���G���A�ɓ����Ă��邩�ǂ������`�F�b�N
        bool isPlayerInMoveAdaptiveArea = false;
        foreach (var player in playerObjects)
        {
            if (moveAdaptiveArea.bounds.Contains(player.transform.position))
            {
                isPlayerInMoveAdaptiveArea = true;
                break;
            }
        }

        // �ړ��K���G���A���Ƀv���C���[������ꍇ�݈̂ړ���K������
        if (isPlayerInMoveAdaptiveArea)
        {
            if (!isMoving)
            {
                // �ړ��J�n���̉����x��K�p���ď��X�ɑ��x���グ��
                currentSpeed += accelerationRate * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0f, moveSpeed); // �ő呬�x�𐧌�

                if (currentSpeed >= moveSpeed)
                {
                    isMoving = true;
                }
            }
            else
            {
                // �ڕW�n�_�Ɍ������Ĉړ�
                MoveToWaypoint();
            }
        }
        else
        {
            if (isMoving)
            {
                // ��~���̌����x��K�p���ď��X�ɑ��x��������
                currentSpeed -= decelerationRate * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0f, moveSpeed); // �ŏ����x�𐧌�

                if (currentSpeed <= 0f)
                {
                    isMoving = false;
                }
            }
        }
    }

    void MoveToWaypoint()
    {
        // ���݂̖ڕW�n�_���z��͈͓̔��ɂ��邩�m�F
        if (currentWaypointIndex < waypoints.Length)
        {
            // �ڕW�n�_�ւ̕����x�N�g�����v�Z
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            direction.y = 0f; // �J�����𐅕��ɐ�������

            // �ڕW�n�_�ɏ\���߂Â����玟�̖ڕW�n�_�ֈړ�
            if (direction.magnitude < 0.1f)
            {
                currentWaypointIndex++;
            }
            else
            {
                // �ړ������Ɋ�Â��ăJ�������ړ�������
                transform.Translate(direction.normalized * currentSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
