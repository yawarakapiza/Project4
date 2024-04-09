using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    void Update()
    {
        // マウスの位置を取得
        Vector3 mousePosition = Input.mousePosition;

        // カメラからマウスの位置までのベクトルを取得
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));

        // y軸の位置をGunオブジェクトのy座標に固定
        worldMousePosition.y = transform.position.y;

        // Gunオブジェクトがカーソルの方向を向くようにする
        transform.LookAt(worldMousePosition, Vector3.up);
    }
}
