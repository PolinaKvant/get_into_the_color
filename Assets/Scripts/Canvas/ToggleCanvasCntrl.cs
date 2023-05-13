using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Canvas
{
    public class ToggleCanvasCntrl : MonoBehaviour
    {
        [SerializeField] private List<CanvasBase> _canvasList;
        private SignalBus _signalBus;
        
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Start()
        {
            _signalBus.Subscribe<ToggleCanvasSignal>(ShowCanvas);
        }

        private void ShowCanvas(ToggleCanvasSignal showCanvasSignal)
        {
            foreach (var canvas in _canvasList)
            {
                if (canvas.Id.Equals(showCanvasSignal.CanvasId))
                {
                    canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
                }
            }
        }
    }
}