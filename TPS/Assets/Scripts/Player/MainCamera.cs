using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject[] targetObjects;   // 追跡対象のオブジェクトの配列
    public Vector3 offset;              // カメラとの相対距離
    private int currentTargetIndex = 0;  // 現在の追跡対象のインデックス

    // Start is called before the first frame update
    void Start()
    {
        if (targetObjects != null && targetObjects.Length > 0)
        {
            SetTarget(currentTargetIndex); // 初期の追跡対象を設定
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
            // カメラの位置を設定したオブジェクトの位置にオフセットを加えた位置にする
            transform.position = targetObjects[currentTargetIndex].transform.position + offset;
        }
    }

    // 指定したインデックスの追跡対象を設定する
    public void SetTargetIndex(int index)
    {
        if (index >= 0 && index < targetObjects.Length)
        {
            SetTarget(index);
        }
    }

    // 追跡対象を切り替える
    private void SetTarget(int index)
    {
        if (index >= 0 && index < targetObjects.Length)
        {
            currentTargetIndex = index;
        }
    }
}
