
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    public string namePlayer = "";
    public string nameEnemy = "";
    private static SaveController _instance;

    private string saveWinnerKey = "SaveWinner";
    private string saveLastScore = "SaveLastScore";



    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";

        colorPlayer = Color.white;
        colorEnemy = Color.white;
    }


    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                // Procure a instância na cena
                _instance = FindObjectOfType<SaveController>();
                // Se não encontrar, crie uma nova instância
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(saveWinnerKey, winner);
    }
    
    public string GetLastWinner()
    {

        return PlayerPrefs.GetString(saveWinnerKey);
    }

    public void SaveLastScore(string score)
    {
        PlayerPrefs.SetString(saveLastScore, score);
    }
    
    public string GetLastScore()
    {

        return PlayerPrefs.GetString(saveLastScore);
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);

    }
    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void ClearSave(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
