using UnityEngine;
using UnityEngine.UI;

public class AbilitySelector : MonoBehaviour
{
    // 定義玩家能力的列舉類型
    public enum PlayerAbility
    {
        Health, // 速度
        Attack // 攻擊力
    }

    // 下拉列表UI元素
    public Dropdown abilityDropdown;

    // 當前選擇的玩家能力
    private PlayerAbility _selectedAbility;

    // 當下拉列表選擇發生改變時調用的方法
    public void OnAbilitySelected(int index)
    {
        _selectedAbility = (PlayerAbility)index;
    }
}