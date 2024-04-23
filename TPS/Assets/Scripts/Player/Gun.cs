using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Player
{
    public GameObject BulletPrefab; // 生成する弾オブジェクトのプレハブ
    public GameObject bulletSpawnPoint; // 弾を生成する位置のオブジェクト
    public float fireRate = 0.5f; // 発射レート（1秒あたりの発射数）
    public float bulletSpeed = 10f; // 発射レート（1秒あたりの発射数）
    public Vector3 mouseOffset = new Vector3(20, 20, 0); // マウス位置からのオフセット
    public float spreadAngle = 5f; // 発射のばらつき角度

    private float nextFireTime = 0f; // 次に発射可能な時間

    protected override void Update()
    {
        // Gunオブジェクトの方向を更新する
        Vector3 mousePosition = Input.mousePosition + mouseOffset;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));
        worldMousePosition.y = transform.position.y;
        transform.rotation = Quaternion.LookRotation(worldMousePosition - transform.position);

        // マウスの左ボタンが押されていて、次に発射可能な時間になっているかを確認
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Vector3 spawnPoint = bulletSpawnPoint.transform.position;

            // 発射方向にランダムな回転を加える
            Quaternion spreadRotation = Quaternion.Euler(Random.Range(-spreadAngle, spreadAngle), Random.Range(-spreadAngle, spreadAngle), 0);
            Quaternion bulletRotation = transform.rotation * spreadRotation;

            // 弾を生成
            GameObject bullet = Instantiate(BulletPrefab, spawnPoint, bulletRotation);

            // Rigidbodyコンポーネントを取得して弾を発射
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed; // 適切な速度を設定
            }

            // 次の発射可能時間を設定
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
