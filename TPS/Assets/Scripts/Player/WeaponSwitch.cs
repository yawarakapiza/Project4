using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] guns; // Gunオブジェクトの配列
    private int currentGunIndex = 0; // 現在アクティブなGunオブジェクトのインデックス

    void Start()
    {
        // 初期状態で最初の銃以外を非アクティブにする
        UpdateWeaponActiveState();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 右クリックが押されたかを検出（0: 左クリック, 1: 右クリック, 2: 中クリック）
        {
            SwitchWeapon();
        }
    }

    void SwitchWeapon()
    {
        // 現在の銃を非アクティブにする
        guns[currentGunIndex].SetActive(false);

        // 次の銃のインデックスを計算する
        currentGunIndex = (currentGunIndex + 1) % guns.Length; // 配列の長さで割った余りを取ることで循環させる

        // 新しい銃をアクティブにする
        guns[currentGunIndex].SetActive(true);
    }

    // すべての銃を非アクティブにし、現在選択されている銃だけをアクティブにする
    void UpdateWeaponActiveState()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
        guns[currentGunIndex].SetActive(true);
    }
}
