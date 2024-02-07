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
                Debug.Log("�α��� ����: " + userid);
                SceneManager.LoadScene("MainScene");
            }
            else
            {
                Debug.LogWarning("��й�ȣ�� ��ġ���� �ʽ��ϴ�.");
                IncorrectPanel.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("����ڰ� �������� �ʽ��ϴ�.");
            IncorrectPanel.SetActive(true);
        }
    }

    public void CloseIncorrectPanel()
    {
        IncorrectPanel.SetActive(false);
    }
}
