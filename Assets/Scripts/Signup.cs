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
        string userid = IDInput.text;    // 입력된 사용자명
        string username = NameInput.text;
        string password = passwordInput.text;    // 입력된 비밀번호
        string pwconfirm = pwconfirmInput.text;

        if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(password))
        {
            IncorrectPanel.SetActive(true);
            Debug.LogWarning("사용자명과 비밀번호는 비어있을 수 없습니다.");
            return;
        }

        // 사용자가 이미 존재하는지 확인합니다.
        if (PlayerPrefs.HasKey(userid))
        {
            IncorrectPanel.SetActive(true);
            Debug.LogWarning("이미 사용자가 존재합니다.");
            return;
        }

        // 비밀번호와 비밀번호 확인이 같은지 확인
        if (passwordInput != pwconfirmInput)
        {
            IncorrectPanel.SetActive(true);
            Debug.LogWarning("비밀번호가 일치하지 않습니다.");
            return;
        }

        // PlayerPrefs를 사용하여 사용자 데이터를 저장합니다.
        PlayerPrefs.SetString(userid, password);
        PlayerPrefs.Save();

        Debug.Log("사용자 등록 완료: " + userid);
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
