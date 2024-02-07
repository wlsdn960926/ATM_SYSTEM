using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Signup : MonoBehaviour
{
    public TMP_InputField IDInput;
    public TMP_InputField NameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField pwconfirmInput;
    public Button registerButton;
    public Button CancelButton;
    public GameObject SignupPanel;
    public GameObject IncorrectPanel;

    private void Start()
    {
        registerButton.onClick.AddListener(RegisterUser);
    }

    private void RegisterUser()
    {
        string userid = IDInput.text;    // �Էµ� ����ڸ�
        string username = NameInput.text;
        string password = passwordInput.text;    // �Էµ� ��й�ȣ
        string pwconfirm = pwconfirmInput.text;

        if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(password))
        {
            IncorrectPanel.SetActive(true);
            Debug.LogWarning("����ڸ�� ��й�ȣ�� ������� �� �����ϴ�.");
            return;
        }

        // ����ڰ� �̹� �����ϴ��� Ȯ���մϴ�.
        if (PlayerPrefs.HasKey(userid))
        {
            IncorrectPanel.SetActive(true);
            Debug.LogWarning("�̹� ����ڰ� �����մϴ�.");
            return;
        }

        // ��й�ȣ�� ��й�ȣ Ȯ���� ������ Ȯ��
        if (passwordInput != pwconfirmInput)
        {
            IncorrectPanel.SetActive(true);
            Debug.LogWarning("��й�ȣ�� ��ġ���� �ʽ��ϴ�.");
            return;
        }

        // PlayerPrefs�� ����Ͽ� ����� �����͸� �����մϴ�.
        PlayerPrefs.SetString(userid, password);
        PlayerPrefs.Save();

        Debug.Log("����� ��� �Ϸ�: " + userid);
        CloseSignupPanel();
    }

    public void OpenSignupPanel()
    {
        SignupPanel.SetActive(true);
    }
    public void CloseSignupPanel()
    {
        SignupPanel.SetActive(false);
    }
    public void CloseIncorrectPanel()
    {
        IncorrectPanel.SetActive(false);
    }
}
