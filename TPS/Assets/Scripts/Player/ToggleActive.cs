using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    public GameObject[] targetObjects; // 対象のオブジェクトを格納する配列
    private Vector3[] objectPositions; // 対象のオブジェクトの初期位置を格納する配列
    //座標
    int x = 0;

    public bool isModeChange = false; // モード変更フラグ

    public float cooldownTime = 1.0f; // クールダウン時間
    private float cooldownTimer = 0.0f; // クールダウンタイマー

    void Start()
    {
        // 対象のオブジェクトの初期位置を保存するための配列を初期化
        objectPositions = new Vector3[targetObjects.Length];

        // 初期位置を保存
        for (int i = 0; i < targetObjects.Length; i++)
        {
            objectPositions[i] = targetObjects[i].transform.position;
        }
    }

    void Update()
    {
        // クールダウン中は処理しない
        if (cooldownTimer > 0.0f)
        {
            cooldownTimer -= Time.deltaTime;
            return;
        }

        // オブジェクトの位置が変わったら更新
        for (int i = 0; i < targetObjects.Length; i++)
        {
            if (targetObjects[i].transform.position != objectPositions[i])
            {
                objectPositions[i] = targetObjects[i].transform.position;
                x = i;
                //Debug.Log("Object " + targetObjects[i].name + " position updated: " + objectPositions[i]);
            }
        }

        // スペースキーが押されたらモード変更フラグを切り替える
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isModeChange = !isModeChange;
            Debug.Log("Mode change: " + isModeChange);

            // モードが変更されたら追跡対象を切り替える
            if (isModeChange)
            {
                // Element 0 を非アクティブにし、Element 1 をアクティブにする
                if (targetObjects.Length > 1 && targetObjects[0] != null && targetObjects[1] != null)
                {
                    // Element 0 を非アクティブにし、Element 1 をアクティブにして初期位置に移動させる
                    targetObjects[0].SetActive(false);
                    targetObjects[1].SetActive(true);
                    targetObjects[1].transform.position = objectPositions[x];
                }
            }
            else
            {
                // Element 1 を非アクティブにし、Element 0 をアクティブにする
                if (targetObjects.Length > 1 && targetObjects[0] != null && targetObjects[1] != null)
                {
                    // Element 1 を非アクティブにし、Element 0 をアクティブにして初期位置に移動させる
                    targetObjects[1].SetActive(false);
                    targetObjects[0].SetActive(true);
                    targetObjects[0].transform.position = objectPositions[x];
                }
            }

            // クールダウンを開始する
            cooldownTimer = cooldownTime;
        }
    }
}
