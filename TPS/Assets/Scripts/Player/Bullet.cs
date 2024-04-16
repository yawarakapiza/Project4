using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 2f; // 消去までの待機時間（秒）

    void Start()
    {
        // 指定秒後にDestroyメソッドを呼び出して自分自身（このBulletオブジェクト）を消去する
        Destroy(gameObject, destroyDelay);
    }
}
