using Canvas;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TimeRuleCanvasCntrl : CanvasBase
{
    [SerializeField] private int _secondsCount;
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _countText;

    private int _count;
    private float _timerCount;
    private SignalBus _signalBus;
    private bool _isEndGame;
    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    private void Start()
    {
        _timerCount = _secondsCount;
        _timerText.text = _timerCount.ToString();
        _countText.text = _count.ToString();
        _signalBus.Subscribe<UserShootSignal>(UpdateState);
    }
    public void UpdateState(UserShootSignal userShootSignal)
    {
        if (userShootSignal.IsCorrectShoot)
        {
            _count++;
            _countText.text = _count.ToString();
        }
    }

    private void Update()
    {
        if (_isEndGame) return;
        _timerCount -= Time.deltaTime;
        if (_timerCount <= 0)
        {
            _signalBus.Fire(new EndGameSignal());
            _signalBus.Fire(new ToggleCanvasSignal() { CanvasId = CanvasId.EndGame });
            _timerCount = 0;
            _isEndGame = true;
        }

        _timerText.text = Mathf.Round(_timerCount).ToString();
    }
}
