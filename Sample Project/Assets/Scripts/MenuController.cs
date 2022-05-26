using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuController : MonoBehaviour
{
    [SerializeField] static MenuController Instance;
    public GameObject[] characterKind;
    public static GameObject character;
    public TextMeshProUGUI foxScore;
    public TextMeshProUGUI humanScore;
    public TextMeshProUGUI dogScore;


    TMP_InputField inputField; //to input Player Name
    public static string playerName;
    private Hashtable highscore = new Hashtable();
    private Hashtable userName = new Hashtable();
    private string[] usedcharacter;

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
        LoadScore();
        //get player name
        inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        humanScore.text = "Human High Score: " + userName["Human"] + ":";
        foxScore.text = "Fox High Score: " + userName["Fox"] + ":";
        dogScore.text = "Dog High Score: " + userName["Dog"] + ":";
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

    //get high score and name from json
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            
            
            for(int i =0; i < 3; i++)
            {
                usedcharacter[i] = data.characterName[i];
                highscore[usedcharacter[i]] = data.highScore[usedcharacter[i]];
                userName[usedcharacter[i]] = data.highScoreName[usedcharacter[i]];
            }
        }
    }

}


//Set class to save score and name
[System.Serializable] class SaveData
{
    public Hashtable highScoreName;
    public Hashtable highScore;
    public string[] characterName;
}
