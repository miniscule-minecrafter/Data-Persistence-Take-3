using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuUiHandler : MonoBehaviour
{
    public Text lastPlayer;

    private void Start()
    {
        if (PersistenceData.instance.playerName != "" && PersistenceData.instance.highScore > 0)
        {
            lastPlayer.text = "Best Score : " + PersistenceData.instance.playerName + " : " + PersistenceData.instance.highScore;
        }
        else
        {
            lastPlayer.text = string.Empty;
        }
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetHighScore()
    {
        PersistenceData.instance.playerName = "";
        PersistenceData.instance.highScore = 0;

        lastPlayer.text = string.Empty;

        PersistenceData.instance.Save();
    }

    public void Exit()
    {
        PersistenceData.instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
