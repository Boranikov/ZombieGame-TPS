using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject controlsPanel;
    public GameObject gamePanel;
    public GameObject endPanel;
    public GameObject timerBox;

    [Header("UI Texts")]
    public TMP_Text timerText;
    public TMP_Text missionText;
    public TMP_Text resultText;

    [Header("Player & Settings")]
    public GameObject player;
    public float missionTime = 120f; 

    private float timer;
    private bool missionActive = false;
    private bool missionEnded = false;
    private bool reachedA = false;

    private PlayerHealth playerHealth;
    private PlayerGui playerGui; 

    void Start()
    {
        Time.timeScale = 0f;

        playerHealth = player.GetComponent<PlayerHealth>();
        playerGui = player.GetComponent<PlayerGui>(); 

        mainMenuPanel.SetActive(true);
        controlsPanel.SetActive(false);
        gamePanel.SetActive(false);
        endPanel.SetActive(false);
        timerBox.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (!missionActive || missionEnded) return;

        timer -= Time.deltaTime;
        timerText.text = $"{timer:F1} sn";

        if (timer <= 0f)
        {
            MissionFailed("Görev başarısız! Süre doldu!");
            return;
        }

        if (playerHealth != null && playerHealth.IsDead())
        {
            MissionFailed("Öldün!");
        }
    }

    public void StartMission()
    {
        Time.timeScale = 1f;

        mainMenuPanel.SetActive(false);
        controlsPanel.SetActive(false);
        gamePanel.SetActive(true);
        endPanel.SetActive(false);
        timerBox.SetActive(true);

        missionActive = true;
        missionEnded = false;
        reachedA = false;
        timer = missionTime;

        missionText.text = "Görev: Canavarları öldür ve helikoptere ulaş!";

        if (playerGui != null)
            playerGui.EnableCrosshair(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ReachTargetA()
    {
        if (!reachedA)
        {
            reachedA = true;
            missionText.text = "Canavarları temizledin! Şimdi helikoptere ulaş!";
        }
    }


    public void ReachTargetB()
    {
        if (!reachedA)
        {
            missionText.text = "Önce canavarları temizlemelisin!";
            return;
        }

        MissionSuccess();
    }


    void MissionSuccess()
    {
        missionActive = false;
        missionEnded = true;

        gamePanel.SetActive(false);
        timerBox.SetActive(false);
        endPanel.SetActive(true);

        resultText.text = "Görev Tamamlandı ✅";

        if (playerGui != null)
            playerGui.EnableCrosshair(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void MissionFailed(string reason)
    {
        if (missionEnded) return;

        missionActive = false;
        missionEnded = true;

        gamePanel.SetActive(false);
        timerBox.SetActive(false);
        endPanel.SetActive(true);

        resultText.text = reason;

        if (playerGui != null)
            playerGui.EnableCrosshair(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RetryMission()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenControls()
    {
        mainMenuPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        controlsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
