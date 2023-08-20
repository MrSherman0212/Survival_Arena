using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameSessionManager : MonoBehaviour, IInitializable
{
    [Header("Timer")]
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private float _givenTime = 100;
    private float _timer;
    [Header("ScoresUI")]
    [SerializeField] private TMP_Text _scoreText;
    private int _scores;
    [Header("Panels")]
    [SerializeField] private Image _menuScreen;
    [SerializeField] private Image _gameOverScreen;
    [SerializeField] private Image _winScreen;

    public int Scores { set { _scores = value; } }

    public delegate void WinEvent();
    public static WinEvent OnWinEvent;

    public delegate void StartEvent();
    public static StartEvent OnStartEvent;

    public void Init()
    {
        _timer = _givenTime;
        _scores = 0;
        OnStartEvent.Invoke();
    }

    private void Update()
    {
        if (_timer >= 0) CountDownTimer();
        else DoWinScreen();
    }

    private void CountDownTimer()
    {
        _timer -= Time.deltaTime;
        float value = Mathf.Ceil(_timer);
        SetUI(_timerText, value);
    }

    private void DoWinScreen()
    {
        _winScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void DoGameOverScreen()
    {
        _gameOverScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void SetUI(TMP_Text text, float value)
    {
        text.text = value.ToString();
    }

    public void AddScore()
    {
        _scores++;
        SetUI(_scoreText, _scores);
    }

    private void OnEnable()
    {
        EnemyHealthSystem.OnDieEvent += AddScore;
        PlayerHealthSystem.OnDieEvent += DoGameOverScreen;
    }

    private void OnDisable()
    {
        EnemyHealthSystem.OnDieEvent -= AddScore;
        PlayerHealthSystem.OnDieEvent -= DoGameOverScreen;
    }
}