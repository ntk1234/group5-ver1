using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilityDropdown : MonoBehaviour
{
    // 用於顯示玩家能力的 Dropdown UI 組件
    public Dropdown playerAbilityDropdown;

    // GameManager 腳本
    public GameManager gameManager;

    private void Start()
    {
        // 將 GameManager 腳本設置為 gameManager 變量
        gameManager = FindObjectOfType<GameManager>();

        // 設置 Dropdown UI 組件的選項
        playerAbilityDropdown.options.Clear();
        playerAbilityDropdown.options.Add(new Dropdown.OptionData("增強攻擊力"));
        playerAbilityDropdown.options.Add(new Dropdown.OptionData("增強生命值"));

        // 註冊 Dropdown UI 組件的 OnValueChanged 事件
        playerAbilityDropdown.onValueChanged.AddListener(OnPlayerAbilityDropdownChanged);
    }

    private void OnPlayerAbilityDropdownChanged(int index)
    {
        // 根據選擇的選項，調用 GameManager 腳本的 SelectPlayerAbility 方法
        if (index == 0)
        {
            gameManager.SelectPlayerAbility(PlayerAbility.Attack);
        }
        else if (index == 1)
        {
            gameManager.SelectPlayerAbility(PlayerAbility.Health);
        }
    }
}