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
        // 設置 Dropdown UI 組件的選項
        playerAbilityDropdown.options.Clear();
        playerAbilityDropdown.options.Add(new Dropdown.OptionData("增強攻擊力"));
        playerAbilityDropdown.options.Add(new Dropdown.OptionData("增強生命值"));

        // 註冊 Dropdown UI 組件的 OnValueChanged 事件
        playerAbilityDropdown.onValueChanged.AddListener(OnPlayerAbilityDropdownChanged);

        // 獲取分數組件
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        UpdateScoreText(); // 更新分數文本
    }

    private void Update()
    {
        // 此處可以添加其他更新邏輯
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreText(); // 更新分數文本
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
        // 根據選擇的選項，設置玩家能力
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
        // 顯示 Dropdown UI 組件
        playerAbilityDropdown.gameObject.SetActive(true);
    }

    public void StartNextLevel()
    {
        // 加載下一關遊戲場景
        SceneManager.LoadScene(nextLevelSceneName);
    }

    public void GameOver()
    {
        // 重新加載當前場景
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
