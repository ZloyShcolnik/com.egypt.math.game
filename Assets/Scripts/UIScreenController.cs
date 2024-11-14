using UnityEngine;

public class UIScreenController : MonoBehaviour
{
    private GameObject lastCanvas;

    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject rulesCanvas;
    [SerializeField] GameObject settingsCanvas;
    [SerializeField] GameObject exitCanvas;

    [Space(10)]
    [SerializeField] GameObject level;

    public void OpenCanvas(string name)
    {
        if (lastCanvas != null)
        {
            lastCanvas.SetActive(false);
        }

        lastCanvas = name switch
        {
            "menu" => menuCanvas,
            "game" => gameCanvas,
            "rules" => rulesCanvas,
            "settings" => settingsCanvas,
            "exit" => exitCanvas,
            _ => menuCanvas
        };

        SelectSfx.Instant();
        lastCanvas.SetActive(true);

        if(string.Equals(name, "game"))
        {
            level.SetActive(true);
        }
    }
}
