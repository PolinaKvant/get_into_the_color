using TMPro;
using UnityEngine;
using Zenject;

public class TargetCntrl : MonoBehaviour
{
    private SignalBus _signalBus;
    private const float ALPHAONHOVER = 0.5f;
    private const float ALPHAOUTHOVER = 1f;
    private Color _trueColor;
    
    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    public void Hit(Color weaponColor)
    {
        _signalBus.Fire(new UserShootSignal()
        {
            IsCorrectShoot = weaponColor.Compare(_trueColor)
        });
        _signalBus.Fire(new UpdateColorSignal());
    }

    public void OnHover()
    {
        var color = GetComponent<MeshRenderer>().material.color;
        color.a = ALPHAONHOVER;
        GetComponent<MeshRenderer>().material.color = color;
    }

    public void OutHover()
    {
        var color = GetComponent<MeshRenderer>().material.color;
        color.a = ALPHAOUTHOVER;
        GetComponent<MeshRenderer>().material.color = color;
    }

    public void ChangeColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
        _trueColor = color;
    }
}
