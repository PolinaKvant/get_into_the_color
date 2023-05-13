using System;
using Canvas;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CountRuleCanvasCntrl : CanvasBase
{
    [SerializeField] private int _maxCount;
    [SerializeField] private float _timeForLose;
    [SerializeField] private Text _stopWatchText;
    [SerializeField] private Text _countText;

    private int _count;
    private float _timerCount = 0f;
    private SignalBus _signalBus;
    private bool _isEndGame;
    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    private void Start()
    {
        _stopWatchText.text = _timerCount.ToString("F2");
        _countText.text = _count.ToString();
        _signalBus.Subscribe<UserShootSignal>(UpdateState);
    }

    private void Update()
    {
        if(_isEndGame) return;
        _timerCount += Time.deltaTime;
        _stopWatchText.text = _timerCount.ToString("F2");
    }

    public void UpdateState(UserShootSignal userShootSignal)
    {
        if (userShootSignal.IsCorrectShoot)
        {
            _count++;
            if (_count >= _maxCount)
            {
                _signalBus.Fire(new EndGameSignal());
                _signalBus.Fire(new ToggleCanvasSignal(){CanvasId = CanvasId.EndGame});
                _isEndGame = true;
            }
            _countText.text = _count.ToString();
        }
        else
        {
            _timerCount += _timeForLose;
        }
    }
}
