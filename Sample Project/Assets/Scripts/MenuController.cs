using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class MenuController : MonoBehaviour
{
    [SerializeField] static MenuController Instance;
    public GameObject[] characterKind;
    public static GameObject character;
    public static int index;
    public TextMeshProUGUI foxScore;
    public TextMeshProUGUI humanScore;
    public TextMeshProUGUI dogScore;


    TMP_InputField inputField; //to input Player Name
    public static string playerName;
    private Hashtable userHighscore = new Hashtable();
    private Hashtable userName = new Hashtable();
    public static int maxPoint;

    private void Awake()
    {
        // make instance
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!File.Exists(Application.persistentDataPath + "/savedogfile.json"))
        {
        SaveScore();
        }
        
        LoadScore();
        //get player name
        inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        humanScore.text = "Human High Score: " + userName["Human"] + ":"+ userHighscore["Human"];
        foxScore.text = "Fox High Score: " + userName["Fox"] + ":" + userHighscore["Fox"];
        dogScore.text = "Dog High Score: " + userName["Dog"] + ":" + userHighscore["Dog"];
    }

    public void SelectDog()
    {
        character = characterKind[0];
        index = 0;
        maxPoint = Convert.ToInt32(userHighscore["Dog"]);
        SceneManager.LoadScene("Main Scene");
    }

    public void SelectFox()
    {
        character = characterKind[1];
        index = 1;
        maxPoint = Convert.ToInt32(userHighscore["Fox"]);
        SceneManager.LoadScene("Main Scene");
    }

    public void SelectHuman()
    {
        character = characterKind[2];
        index = 2;
        maxPoint = Convert.ToInt32(userHighscore["Human"]);
        SceneManager.LoadScene("Main Scene");
    }

    //set player name
    public void InitInputField()
    {
        playerName = inputField.text;
    }

    //get high score and name from json
    public void LoadScore()
    {
        string path0 = Application.persistentDataPath + "/savedogfile.json";
        string path1 = Application.persistentDataPath + "/savefoxfile.json";
        string path2 = Application.persistentDataPath + "/savehumanfile.json";
        if (File.Exists(path0))
        {
            string json = File.ReadAllText(path0);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            userName["Dog"] = data.playerName;
            userHighscore["Dog"] = data.playerScore;
        }
        if (File.Exists(path1))
        {
            string json = File.ReadAllText(path1);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            userName["Fox"] = data.playerName;
            userHighscore["Fox"] = data.playerScore;
        }
        if (File.Exists(path2))
        {
            string json = File.ReadAllText(path2);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            userName["Human"] = data.playerName;
            userHighscore["Human"] = data.playerScore;
        }
    }

    public void SaveScore()
    {
        SaveData data0 = new SaveData();
        SaveData data1 = new SaveData();
        SaveData data2 = new SaveData();
        //PlayerName get high score
        data0.playerName = "None";
        data1.playerName = "None";
        data2.playerName = "None";
        // high score
        data0.playerScore = 0;
        data1.playerScore = 0;
        data2.playerScore = 0;
        data0.characterName = "Dog";
        data1.characterName = "Fox";
        data2.characterName = "Human";
        
        string json0 = JsonUtility.ToJson(data0);
        File.WriteAllText(Application.persistentDataPath + "/savedogfile.json", json0);
        string json1 = JsonUtility.ToJson(data1);
        File.WriteAllText(Application.persistentDataPath + "/savefoxfile.json", json1);
        string json2 = JsonUtility.ToJson(data2);
        File.WriteAllText(Application.persistentDataPath + "/savehumanfile.json", json2);
    }
    

}


//Set class to save score and name
[System.Serializable] class SaveData
{
    public string playerName;
    public int playerScore;
    public string characterName;
    
}
