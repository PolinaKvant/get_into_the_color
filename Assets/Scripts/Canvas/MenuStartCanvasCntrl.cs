using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Canvas
{
    public class MenuStartCanvasCntrl : CanvasBase
    {
        private MenuSettings _menuSettings;
    
        [Inject]
        public void Construct(MenuSettings menuSettings)
        {
            _menuSettings = menuSettings;
        }
        public void OnClickTimeRule()
        {
            _menuSettings.RuleType = RuleType.TimerRule;
            SceneManager.LoadScene("LevelScene");
        }

        public void OnClickCountRule()
        {
            _menuSettings.RuleType = RuleType.CountRule;
            SceneManager.LoadScene("LevelScene");
        }
    }
}
