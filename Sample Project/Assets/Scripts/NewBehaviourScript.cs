using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Reflection;

/*public class HitCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    public Button resetGame;
    public Button exitGame;
    public static int score;
    public string userName;

    private string methodName;



    void Start()
    {
        methodName = "Save" + MenuController.character.tag + "Score";

        score = 0;
        scoreText.text = "Score: " + score;
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
            if (score > MenuController.maxPoint)
            {
                Debug.Log("High Score!");
                Invoke(methodName, 0f);
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



    //Save High Score
    public void SaveDogScore()
    {
        SaveData data = new SaveData();
        //PlayerName get high score
        data.playerName = MenuController.playerName;
        // high score
        data.playerScore = score;
        data.characterName = "Dog";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedogfile.json", json);
    }

    public void SaveFoxScore()
    {
        SaveData data = new SaveData();
        //PlayerName get high score
        data.playerName = MenuController.playerName;
        // high score
        data.playerScore = score;
        data.characterName = "Fox";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefoxfile.json", json);
    }

    public void SaveHumanScore()
    {
        SaveData data = new SaveData();
        //PlayerName get high score
        data.playerName = MenuController.playerName;
        // high score
        data.playerScore = score;
        data.characterName = "Human";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savehumanfile.json", json);
    }




}*/
