using UnityEngine.SceneManagement;

public class EndGameCanvasCntrl : CanvasBase
{
    public void ReloadGame()
    {
        SceneManager.LoadScene("MenuScene2");
    }
}
