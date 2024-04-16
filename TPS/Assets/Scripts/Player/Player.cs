using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // 通常の移動速度
    public float rotationSpeed = 10f; // 通常の向きの変更速度
    protected Rigidbody rb; // Rigidbody コンポーネントの参照
    //private bool isBallMode = false; // Ballモードかどうかのフラグ

    protected virtual void Start()
    {
        // Rigidbody コンポーネントを取得
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {

        // キー入力を取得して通常の移動ベクトルを計算
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // 通常の移動方向に速度を加える
        rb.velocity = moveDirection * moveSpeed;

        // 移動方向がある場合にのみ向きを変更する
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // キーが離された場合、即座に停止する
            rb.velocity = Vector3.zero;
        }
    }

}