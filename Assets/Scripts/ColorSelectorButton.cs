using UnityEngine.UI;
using UnityEngine;

public class ColorSelectorButton : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;

    public bool isColorPlayer;

    public void OnButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;
        if (isColorPlayer)
        {
            SaveController.Instance.colorPlayer = paddleReference.color;
        }
        else
        {
            SaveController.Instance.colorEnemy = paddleReference.color;

        }
    }
}
