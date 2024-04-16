using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform[] waypoints; // 移動先の空のオブジェクトを格納する配列
    public float moveSpeed = 5f; // 移動速度
    public Collider moveAdaptiveArea; // 移動適応エリアのコライダー
    public GameObject[] playerObjects; // 手動で選択するPlayerオブジェクトの配列
    public float accelerationRate = 1.0f; // 移動開始時の加速度
    public float decelerationRate = 1.0f; // 停止時の減速度

    private int currentWaypointIndex = 0; // 現在の目標地点のインデックス
    private bool isMoving = false; // 移動中かどうかのフラグ
    private float currentSpeed = 0f; // 現在の移動速度

    void Update()
    {
        // 手動で選択されたPlayerオブジェクトが移動適応エリアに入っているかどうかをチェック
        bool isPlayerInMoveAdaptiveArea = false;
        foreach (var player in playerObjects)
        {
            if (moveAdaptiveArea.bounds.Contains(player.transform.position))
            {
                isPlayerInMoveAdaptiveArea = true;
                break;
            }
        }

        // 移動適応エリア内にプレイヤーがいる場合のみ移動を適応する
        if (isPlayerInMoveAdaptiveArea)
        {
            if (!isMoving)
            {
                // 移動開始時の加速度を適用して徐々に速度を上げる
                currentSpeed += accelerationRate * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0f, moveSpeed); // 最大速度を制限

                if (currentSpeed >= moveSpeed)
                {
                    isMoving = true;
                }
            }
            else
            {
                // 目標地点に向かって移動
                MoveToWaypoint();
            }
        }
        else
        {
            if (isMoving)
            {
                // 停止時の減速度を適用して徐々に速度を下げる
                currentSpeed -= decelerationRate * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0f, moveSpeed); // 最小速度を制限

                if (currentSpeed <= 0f)
                {
                    isMoving = false;
                }
            }
        }
    }

    void MoveToWaypoint()
    {
        // 現在の目標地点が配列の範囲内にあるか確認
        if (currentWaypointIndex < waypoints.Length)
        {
            // 目標地点への方向ベクトルを計算
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            direction.y = 0f; // カメラを水平に制限する

            // 目標地点に十分近づいたら次の目標地点へ移動
            if (direction.magnitude < 0.1f)
            {
                currentWaypointIndex++;
            }
            else
            {
                // 移動方向に基づいてカメラを移動させる
                transform.Translate(direction.normalized * currentSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
