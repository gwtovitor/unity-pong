
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;

    void Start()
    {
        SaveController.Instance.Reset();
        string lastWinner = SaveController.Instance.GetLastWinner();
        string lastScore = SaveController.Instance.GetLastScore();

        if (lastWinner != "")
        {
            uiWinner.text = $"Ultimo vencedor: {lastWinner}" + (lastScore != null ? $" Com o Score: {lastScore}" : "");
        }
        else
        {
            uiWinner.text = "";
        }
    }
}
