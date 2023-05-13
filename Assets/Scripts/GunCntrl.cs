#nullable enable
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunCntrl : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable _xrGrabInteractable;
    [SerializeField] private GameObject _colorFiller;
    private TargetCntrl? _prevTargetCntrl;
    private Ray _ray;

    public void Start()
    {
        _xrGrabInteractable.activated.AddListener(Shoot);
    }

    public void Update()
    {
        _ray = new Ray(transform.position, transform.forward);

        if (_prevTargetCntrl is not null)
        {
            _prevTargetCntrl.OutHover();
            _prevTargetCntrl = null;
        }

        RaycastHit hit;
        if (!Physics.Raycast(_ray, out hit)) return;

        var obj = hit.collider.GetComponent<TargetCntrl>();
        if (obj is null) return;
        
        obj.OnHover();
        _prevTargetCntrl = obj;
    }

    public void Shoot(ActivateEventArgs args)
    {
        _ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (!Physics.Raycast(_ray, out hit) || hit.transform.GetComponent<TargetCntrl>() is null) return;
        hit.transform.GetComponent<TargetCntrl>().Hit(_colorFiller.GetComponent<MeshRenderer>().material.color);
    }

    public void ChangeColor(Color color)
    {
        _colorFiller.GetComponent<MeshRenderer>().material.color = color;
    }
}
