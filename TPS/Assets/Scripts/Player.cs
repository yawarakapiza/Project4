using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public float rotationSpeed = 10f; // 向きの変更速度

    private Rigidbody rb; // Rigidbody コンポーネントの参照

    void Start()
    {
        // Rigidbody コンポーネントを取得
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // キー入力を取得して移動ベクトルを計算
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // 移動方向を計算
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // 移動方向がある場合にのみ向きを変更する
        if (moveDirection != Vector3.zero)
        {
            // 目標の向きを計算
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            // 現在の向きから目標の向きに向けて補間する
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // キーが離された場合、即座に停止する
            rb.velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        // キー入力を取得して移動ベクトルを計算
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // 移動方向を計算
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // 移動方向に速度を加える
        rb.velocity = moveDirection * moveSpeed;
    }
}
