using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public TMP_InputField IDInputField;
    public TMP_InputField PWInputField;
    public Button loginButton;
    public GameObject IncorrectPanel;

    private void Start()
    {
        
    }

    public void LoginUser()
    {
        string userid = IDInputField.text;
        string password = PWInputField.text;

        if (PlayerPrefs.HasKey(userid))
        {
            string savedPassword = PlayerPrefs.GetString(userid);

            if (password == savedPassword)
            {
                Debug.Log("로그인 성공: " + userid);
                SceneManager.LoadScene("MainScene");
            }
            else
            {
                Debug.LogWarning("비밀번호가 일치하지 않습니다.");
                IncorrectPanel.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("사용자가 존재하지 않습니다.");
            IncorrectPanel.SetActive(true);
        }
    }

    public void CloseIncorrectPanel()
    {
        IncorrectPanel.SetActive(false);
    }
}
