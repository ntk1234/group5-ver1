using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilityDropdown : MonoBehaviour
{
    // �Ω���ܪ��a��O�� Dropdown UI �ե�
    public Dropdown playerAbilityDropdown;

    // GameManager �}��
    public GameManager gameManager;

    private void Start()
    {
        // �N GameManager �}���]�m�� gameManager �ܶq
        gameManager = FindObjectOfType<GameManager>();

        // �]�m Dropdown UI �ե󪺿ﶵ
        playerAbilityDropdown.options.Clear();
        playerAbilityDropdown.options.Add(new Dropdown.OptionData("�W�j�����O"));
        playerAbilityDropdown.options.Add(new Dropdown.OptionData("�W�j�ͩR��"));

        // ���U Dropdown UI �ե� OnValueChanged �ƥ�
        playerAbilityDropdown.onValueChanged.AddListener(OnPlayerAbilityDropdownChanged);
    }

    private void OnPlayerAbilityDropdownChanged(int index)
    {
        // �ھڿ�ܪ��ﶵ�A�ե� GameManager �}���� SelectPlayerAbility ��k
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