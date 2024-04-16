using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Player
{
    public GameObject BulletPrefab; // 生成する弾オブジェクトのプレハブ
    public GameObject bulletSpawnPoint; // 弾を生成する位置のオブジェクト
    public float fireRate = 0.5f; // 発射レート（1秒あたりの発射数）
    public Vector3 mouseOffset = new Vector3(20, 20, 0); // マウス位置からのオフセット

    private float nextFireTime = 0f; // 次に発射可能な時間

    protected override void Update()
    {
        //base.Update();

        // Gunオブジェクトの方向を更新する
        // マウスの位置からオフセットを加えた位置を取得
        Vector3 mousePosition = Input.mousePosition + mouseOffset;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));
        worldMousePosition.y = transform.position.y;

        // マウスの方向を向く
        transform.rotation = Quaternion.LookRotation(worldMousePosition - transform.position);

        // マウスの左ボタンが押されていて、次に発射可能な時間になっているかを確認
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            // 弾を生成する位置を取得
            Vector3 spawnPoint = bulletSpawnPoint.transform.position;

            // 弾を生成
            GameObject bullet = Instantiate(BulletPrefab, spawnPoint, bulletSpawnPoint.transform.rotation);

            // Rigidbodyコンポーネントを取得して弾を発射
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                // 弾を発射方向に飛ばす
                bulletRigidbody.velocity = bulletSpawnPoint.transform.forward * 10f; // 適切な速度を設定
            }

            // 次の発射可能時間を設定
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
