using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text Cashtxt;
    public Text BalanceTxt;
    public GameObject NotEnoughCashPanel;

    // 초기 자금
    private int InitialCash = 100000;
    private int InitialBalance = 50000;
    private int Cash;
    private int Balance;

    // 직접입력 금액
    [SerializeField] private InputField customAmountInput;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    void Start()
    {
        //PlayerPrefs.DeleteAll(); // 모든 저장된 데이터 삭제
        LoadPlayerData();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DepositMenu()
    {
        LoadPlayerData();
        SceneManager.LoadScene("DepositScene");
    }

    public void WithdrawalMenu()
    {
        LoadPlayerData();
        SceneManager.LoadScene("WithdrawalScene");
    }

    public void Mainmenu()
    {
        SavePlayerData();
        SceneManager.LoadScene("MainScene");
    }

    // 플레이어 데이터 저장
    void SavePlayerData()
    {
        PlayerPrefs.SetInt("SavedCash", Cash);
        PlayerPrefs.SetInt("SavedBalance", Balance);
        PlayerPrefs.Save();
    }

    // 플레이어 데이터 로드
    void LoadPlayerData()
    {
        // 저장된 데이터가 있는지 확인하고 있다면 로드, 없다면 초기값 사용
        Cash = PlayerPrefs.HasKey("SavedCash") ? PlayerPrefs.GetInt("SavedCash") : InitialCash;
        Balance = PlayerPrefs.HasKey("SavedBalance") ? PlayerPrefs.GetInt("SavedBalance") : InitialBalance;
    }

    public void UpdateText()
    {
        // 통화 단위 적용
        Cashtxt.text = Cash.ToString("N0");
        BalanceTxt.text = "Balance  " + Balance.ToString("N0");
    }

    public void DepositAmount(int amount) // 입금
    {
        // Cash에서 Balance로 입금
        if (Cash >= amount)
        {
            Cash -= amount;
            Balance += amount;
            SavePlayerData();
            UpdateText();
        }
        else
        {
            NotEnoughCashPanel.SetActive(true);
        }

    }

    public void WithdrawalAmount(int amount)
    {
        // Balance에서 Cash로 출금
        if (Balance >= amount)
        {
            Balance -= amount;
            Cash += amount;
            SavePlayerData();
            UpdateText();
        }
        else
        {
            NotEnoughCashPanel.SetActive(true);
        }
    }
    // 버튼에 연결된 함수들
    public void Deposit10000Won()
    {
        DepositAmount(10000);
    }

    public void Deposit30000Won()
    {
        DepositAmount(30000);
    }

    public void Deposit50000Won()
    {
        DepositAmount(50000);
    }
    public void Withdrawal10000Won()
    {
        WithdrawalAmount(10000);
    }

    public void Withdrawal30000Won()
    {
        WithdrawalAmount(30000);
    }

    public void Withdrawal50000Won()
    {
        WithdrawalAmount(50000);
    }

    // 직접입력 입금
    public void OnClickDeposit()
    {
        // CustomAmountInput에 입력된 값을 정수로 변환
        int customAmount = int.Parse(customAmountInput.text);

        // Cash에서 Balance로 직접입력 금액으로 입금
        if (Cash >= customAmount)
        {
            Cash -= customAmount;
            Balance += customAmount;
            SavePlayerData();
            UpdateText();
        }
        else
        {
            NotEnoughCashPanel.SetActive(true);
        }
    }
    // 직접입력 출금
    public void OnClickWithdrawal()
    {
        int customAmount = int.Parse(customAmountInput.text);

        if (Balance >= customAmount)
        {
            Balance -= customAmount;
            Cash += customAmount;
            SavePlayerData();
            UpdateText();
        }
        else
        {
            NotEnoughCashPanel.SetActive(true);
        }
    }

    //잔액부족 판넬 닫기
    public void CloseNotEnoughCashPanel()
    {
        NotEnoughCashPanel.SetActive(false);
    }
}