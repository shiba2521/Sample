using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuController : MonoBehaviour
{
    [SerializeField] static MenuController menuController;
    public GameObject[] characterKind;
    public static GameObject character;
    public TextMeshProUGUI HighScore;
    
    TMP_InputField inputField; //to input Player Name
    public static string playerName;
    private int maxScore;
    private string userName;

    private void Awake()
    {
        // make instance
        if (menuController == null)
        {
            DontDestroyOnLoad(gameObject);
            menuController = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadScore();
        //get player name
        inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        HighScore.text = "High Score: " + userName + " :" + maxScore;
    }

    public void SelectDog()
    {
        character = characterKind[0];
        SceneManager.LoadScene("Main Scene");
    }

    public void SelectFox()
    {
        character = characterKind[1];
        SceneManager.LoadScene("Main Scene");
    }

    public void SelectHuman()
    {
        character = characterKind[2];
        SceneManager.LoadScene("Main Scene");
    }

    //set player name
    public void InitInputField()
    {
        playerName = inputField.text;
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxScore = data.highScore;
            userName = data.highScoreName;
        }
    }

}

[System.Serializable] class SaveData
{
    public string highScoreName;
    public int highScore;
}
