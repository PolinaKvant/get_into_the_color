using Canvas;
using UnityEngine;
using Zenject;

public class RuleCntrl : MonoBehaviour
{
    private MenuSettings _menuSettings;
    private SignalBus _signalBus;
    [Inject]
    public void Construct(MenuSettings menuSettings, SignalBus signalBus)
    {
        _menuSettings = menuSettings;
        _signalBus = signalBus;
    }

    private void Start()
    {
        _signalBus.Subscribe<StartGameSignal>(StartCanvas);
    }

    private void StartCanvas()
    {
        switch (_menuSettings.RuleType)
        {
            case RuleType.TimerRule:
                _signalBus.Fire(new ToggleCanvasSignal(){CanvasId = CanvasId.TimerRule});
                break;
            case RuleType.CountRule:
                _signalBus.Fire(new ToggleCanvasSignal(){CanvasId = CanvasId.CountRule});
                break;
        }
    }
}
