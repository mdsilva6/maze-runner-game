using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI scoreText3;

    public TextMeshProUGUI nameText1;
    public TextMeshProUGUI nameText2;
    public TextMeshProUGUI nameText3;

    private float playerScore1st;
    private float playerScore2nd;
    private float playerScore3rd;
    private float playerScoreNew;

    private string playerName1st;
    private string playerName2nd;
    private string playerName3rd;
    private string playerNameNew;

    private string playerPrefsScore1st = "Player Score 1st";
    private string playerPrefsScore2nd = "Player Score 2nd";
    private string playerPrefsScore3rd = "Player Score 3rd";
    private string playerPrefsScoreNew = "Player Score New";

    private string playerPrefsName1st = "Player Name 1st";
    private string playerPrefsName2nd = "Player Name 2nd";
    private string playerPrefsName3rd = "Player Name 3rd";
    private string playerPrefsNameNew = "Player Name New";

    private void Awake()
    {
       playerScore1st = PlayerPrefs.GetFloat(playerPrefsScore1st);
       playerScore2nd = PlayerPrefs.GetFloat(playerPrefsScore2nd);
       playerScore3rd = PlayerPrefs.GetFloat(playerPrefsScore3rd);
       playerScoreNew = PlayerPrefs.GetFloat(playerPrefsScoreNew);

        playerName1st = PlayerPrefs.GetString(playerPrefsName1st);
        playerName2nd = PlayerPrefs.GetString(playerPrefsName2nd);
        playerName3rd = PlayerPrefs.GetString(playerPrefsName3rd);
        playerNameNew = PlayerPrefs.GetString(playerPrefsNameNew);

        if (playerScore1st == 0)
        {
            Debug.Log("assigning values for 1st");
            PlayerPrefs.SetString(playerPrefsName1st, "PL1");
            PlayerPrefs.SetFloat(playerPrefsScore1st, 140);
        }
        if (playerScore2nd == 0)
        {
            PlayerPrefs.SetString(playerPrefsName2nd, "PL2");
            PlayerPrefs.SetFloat(playerPrefsScore2nd, 150);
        }
        if (playerScore3rd == 0)
        {
            PlayerPrefs.SetString(playerPrefsName3rd, "PL3");
            PlayerPrefs.SetFloat(playerPrefsScore3rd, 160);
        }
        if (playerScoreNew == 0)
        {
            PlayerPrefs.SetString(playerPrefsNameNew, "PL4");
            PlayerPrefs.SetFloat(playerPrefsScoreNew, 139);
        }

        SortScores();

    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText1.text = playerScore1st.ToString();
        scoreText2.text = playerScore2nd.ToString();
        scoreText3.text = playerScore3rd.ToString();

        nameText1.text = playerName1st;
        nameText2.text = playerName2nd;
        nameText3.text = playerName3rd;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateVariables();
        SortScores();
        UpdateScores();
    }

    void UpdateVariables()
    {
        playerScore1st = PlayerPrefs.GetFloat(playerPrefsScore1st);
        playerScore2nd = PlayerPrefs.GetFloat(playerPrefsScore2nd);
        playerScore3rd = PlayerPrefs.GetFloat(playerPrefsScore3rd);
        playerScoreNew = PlayerPrefs.GetFloat(playerPrefsScoreNew);

        playerName1st = PlayerPrefs.GetString(playerPrefsName1st);
        playerName2nd = PlayerPrefs.GetString(playerPrefsName2nd);
        playerName3rd = PlayerPrefs.GetString(playerPrefsName3rd);
        playerNameNew = PlayerPrefs.GetString(playerPrefsNameNew);
    }

    void SortScores()
    {
        if (playerScoreNew < playerScore3rd)
        {
            Swap(playerPrefsNameNew, playerPrefsScoreNew, playerPrefsName3rd, playerPrefsScore3rd);
        }

        UpdateVariables();

        if (playerScore3rd < playerScore2nd)
        {
            Swap(playerPrefsName3rd, playerPrefsScore3rd, playerPrefsName2nd, playerPrefsScore2nd);
        }

        UpdateVariables();

        if (playerScore2nd < playerScore1st)
        {
            Swap(playerPrefsName2nd, playerPrefsScore2nd, playerPrefsName1st, playerPrefsScore1st);
        }

        UpdateVariables();
    }

    void Swap(string smallerPlayerNameKey, string smallerScoreNameKey, string greaterPlayerNameKey, string greaterScoreNameKey)
    {
        string smallerPlayerName = PlayerPrefs.GetString(smallerPlayerNameKey);
        float smallerPlayerScore = PlayerPrefs.GetFloat(smallerScoreNameKey);

        string greaterPlayerName = PlayerPrefs.GetString(greaterPlayerNameKey);
        float greaterPlayerScore = PlayerPrefs.GetFloat(greaterScoreNameKey);

        PlayerPrefs.SetFloat(smallerScoreNameKey, greaterPlayerScore);
        PlayerPrefs.SetFloat(greaterScoreNameKey, smallerPlayerScore);

        PlayerPrefs.SetString(smallerPlayerNameKey, greaterPlayerName);
        PlayerPrefs.SetString(greaterPlayerNameKey, smallerPlayerName);


    }

    void UpdateScores()
    {
        playerScore1st = PlayerPrefs.GetFloat(playerPrefsScore1st);
        playerScore2nd = PlayerPrefs.GetFloat(playerPrefsScore2nd);
        playerScore3rd = PlayerPrefs.GetFloat(playerPrefsScore3rd);
        playerScoreNew = PlayerPrefs.GetFloat(playerPrefsScoreNew);

        playerName1st = PlayerPrefs.GetString(playerPrefsName1st);
        playerName2nd = PlayerPrefs.GetString(playerPrefsName2nd);
        playerName3rd = PlayerPrefs.GetString(playerPrefsName3rd);
        playerNameNew = PlayerPrefs.GetString(playerPrefsNameNew);

        //scoreText1.text = TimeSpan.FromSeconds(playerScore1st).ToString("mm':'ss':'ff");
        //scoreText2.text = TimeSpan.FromSeconds(playerScore2nd).ToString("mm':'ss':'ff");
        //scoreText3.text = TimeSpan.FromSeconds(playerScore3rd).ToString("mm':'ss':'ff");

        scoreText1.text = playerScore1st.ToString();
        scoreText2.text = playerScore2nd.ToString();
        scoreText3.text = playerScore3rd.ToString();

        nameText1.text = playerName1st;
        nameText2.text = playerName2nd;
        nameText3.text = playerName3rd;
    }
}
