using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas
{
    public class CountdownCanvasCntrl : CanvasBase
    {
        [SerializeField] private Text _timerText;

        private SignalBus _signalBus;
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        void Start()
        {
            _timerText.text = "5";
            StartCoroutine(StartTimer());
        }

        public IEnumerator StartTimer()
        {
            for (int i = 5; i >= 0; i--)
            {
                yield return new WaitForSeconds(1);
                _timerText.text = i.ToString();
            }
            _signalBus.Fire<StartGameSignal>();
            gameObject.SetActive(false);
        }
    }
}
