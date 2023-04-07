using UnityEngine;
using UnityEngine.UI;

public class AbilitySelector : MonoBehaviour
{
    // �w�q���a��O���C�|����
    public enum PlayerAbility
    {
        Health, // �t��
        Attack // �����O
    }

    // �U�ԦC��UI����
    public Dropdown abilityDropdown;

    // ��e��ܪ����a��O
    private PlayerAbility _selectedAbility;

    // ��U�ԦC���ܵo�ͧ��ܮɽեΪ���k
    public void OnAbilitySelected(int index)
    {
        _selectedAbility = (PlayerAbility)index;
    }
}