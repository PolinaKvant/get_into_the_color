using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ColorChangerCntrl : MonoBehaviour
{
    [SerializeField] private List<TargetCntrl> _targetCntrls;
    [SerializeField] private List<GunCntrl> _gunsCntrls;
    [SerializeField] private Color _defaultColor;
    private SignalBus _signalBus;
    private ColorCntrl _colorCntrl;
    
    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
        _colorCntrl = new ColorCntrl();
    }

    private void Start()
    {
        _signalBus.Subscribe<UpdateColorSignal>(UpdateColors);
        _signalBus.Subscribe<StartGameSignal>(SetByStart);
        _signalBus.Subscribe<EndGameSignal>(SetByDefault);
    }

    public void UpdateColors()
    {
        _colorCntrl.ShuffleColors();
        foreach (var target in _targetCntrls)
        {
            target.ChangeColor(_colorCntrl.GetNextColor());
        }

        foreach (var gun in _gunsCntrls)
        {
            gun.ChangeColor(_colorCntrl.GetRandomColor());
        }
    }

    public void SetByDefault()
    {
        foreach (var gun in _gunsCntrls)
        {
            gun.gameObject.SetActive(false);
        }
    }

    public void SetByStart()
    {
        _colorCntrl.ShuffleColors();
        foreach (var target in _targetCntrls)
        {
            target.ChangeColor(_colorCntrl.GetNextColor());
        }

        foreach (var gun in _gunsCntrls)
        {
            gun.ChangeColor(_colorCntrl.GetRandomColor());
            gun.gameObject.SetActive(true);
        }
    }
}
