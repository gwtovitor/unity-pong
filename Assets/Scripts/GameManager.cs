using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BallController ballController;
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public int winPoints = 2;

    public GameObject screenEndGame;

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public TextMeshProUGUI textEndGame;

    private void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        screenEndGame.SetActive(false);
        playerPaddle.position = new Vector3(7f, 0f, 0f);
        enemyPaddle.position = new Vector3(-7f, 0f, 0f);
        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();


    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        bool playerWin = playerScore > enemyScore;
        string winner = SaveController.Instance.GetName(playerWin);
        textEndGame.text = "Vitoria " + winner;


        SaveController.Instance.SaveLastScore(playerWin ? $"{playerScore} - {enemyScore}" : $"{enemyScore} - {playerScore}");

        SaveController.Instance.SaveWinner(winner);

        // Invoke(nameof(LoadMenu), 2f);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();

    }
    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (enemyScore >= winPoints || playerScore >= winPoints)
        {
            EndGame();
        }
    }

}
