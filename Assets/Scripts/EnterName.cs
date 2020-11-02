using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterName : MonoBehaviour
{

    public string nameInput;

    public TMP_InputField inputField;

    public GameObject inputPanel;

    // Start is called before the first frame update
    void Start()
    {
        inputField.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SubmitName();
        }
    }

    public void SubmitName()
    {
        PlayerPrefs.SetString("Player Name New", inputField.text);
        Debug.Log("Name: " + inputField.text );
        string temp = PlayerPrefs.GetString("Player Name New");
        Debug.Log("Name: " + temp);

        Hide();
        RestartGame();
    }

    void Show()
    {
        inputPanel.SetActive(true);
    }

    void Hide()
    {
        inputPanel.SetActive(false);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Maze");
    }
}
