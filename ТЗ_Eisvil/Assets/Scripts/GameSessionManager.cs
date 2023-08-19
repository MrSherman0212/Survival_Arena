using UnityEngine;
using TMPro;

public class GameSessionManager : MonoBehaviour, IInitializable
{
    [Header("Timer")]
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private float _givenTime = 100;
    [SerializeField] private bool _isTimeOver = false;
    private float _timer;
    [Header("ScoresUI")]
    [SerializeField] private TMP_Text _scoreText;
    private int _scores;

    public int Scores { set { _scores = value; } }

    public void Init()
    {
        _timer = _givenTime;
        _scores = 0;
    }

    private void Update()
    {
        if (_timer >= 0) CountDownTimer();
        else _isTimeOver = true;
    }

    private void CountDownTimer()
    {
        _timer -= Time.deltaTime;
        float value = Mathf.Ceil(_timer);
        SetUI(_timerText, value);
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
    }

    private void OnDisable()
    {
        EnemyHealthSystem.OnDieEvent -= AddScore;
    }
}