using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum PlayerAbility
{
    Attack,
    Health
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public Text scoreText;

    private PlayerAbility playerAbility;
    public Dropdown playerAbilityDropdown;

    public string nextLevelSceneName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // �]�m Dropdown UI �ե󪺿ﶵ
        playerAbilityDropdown.options.Clear();
        playerAbilityDropdown.options.Add(new Dropdown.OptionData("�W�j�����O"));
        playerAbilityDropdown.options.Add(new Dropdown.OptionData("�W�j�ͩR��"));

        // ���U Dropdown UI �ե� OnValueChanged �ƥ�
        playerAbilityDropdown.onValueChanged.AddListener(OnPlayerAbilityDropdownChanged);

        // ������Ʋե�
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        UpdateScoreText(); // ��s���Ƥ奻
    }

    private void Update()
    {
        // ���B�i�H�K�[��L��s�޿�
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreText(); // ��s���Ƥ奻
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void SelectPlayerAbility(PlayerAbility ability)
    {
        playerAbility = ability;
    }

    private void OnPlayerAbilityDropdownChanged(int index)
    {
        // �ھڿ�ܪ��ﶵ�A�]�m���a��O
        if (index == 0)
        {
            playerAbility = PlayerAbility.Attack;
        }
        else if (index == 1)
        {
            playerAbility = PlayerAbility.Health;
        }
    }

    public void LevelComplete()
    {
        // ��� Dropdown UI �ե�
        playerAbilityDropdown.gameObject.SetActive(true);
    }

    public void StartNextLevel()
    {
        // �[���U�@���C������
        SceneManager.LoadScene(nextLevelSceneName);
    }

    public void GameOver()
    {
        // ���s�[����e����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
