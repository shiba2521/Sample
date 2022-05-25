using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class HitCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    public Button resetGame;
    public Button exitGame;
    public static int score = 0;
    public string userName;

    private void Awake()
    {
        

    }

    private int maxPoints;
    
    void Start()
    {
        
        scoreText.text = "Score: " + score;
        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        if (PlayerController.gameover == true)
        {
            gameOver.gameObject.SetActive(true);
            resetGame.gameObject.SetActive(true);
            exitGame.gameObject.SetActive(true);
            if(score > maxPoints)
            {
                SaveScore();
            }
        }
    }

    public void ResetGame()
    {
        PlayerController.gameover = false;
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //ゲームプレイ終了
#else
        Application.Quit();//ゲームプレイ終了
#endif 
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScoreName = MenuController.playerName;
        data.highScore = score;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            maxPoints = data.highScore;
            userName = data.highScoreName;

        }
    }
}


