using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] AudioManager audioManager;

    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject audioSettingsUI;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject heroDialogUI;
    [SerializeField] GameObject builderDialogUI;
    [SerializeField] GameObject blacksmithDialogUI;
    [SerializeField] GameObject princeDialogUI;

    [SerializeField] GameObject CreditsUI;
    [SerializeField] Transform creditsPOS;

    [SerializeField] Transform creditsBegin;
    [SerializeField] Transform creditsEnd;


    [SerializeField] GameObject mainQuit;
    [SerializeField] GameObject pauseQuit;

    bool isPuased = false;
    bool heroActive = false;
    bool builderActive = false;
    bool blacksmithActive = false;
    bool princeActive = false;
    public int CharactersConvosCompleted = 0;
    [HideInInspector] public bool isCurrentlyInDialog = false;
    bool startCredits = false;


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        audioManager = FindObjectOfType<AudioManager>();
        
#if UNITY_WEBGL
        mainQuit.SetActive(false);
        pauseQuit.SetActive(false);
#else
        mainQuit.SetActive(true);
        pauseQuit.SetActive(true);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        handlePause();
        if(CharactersConvosCompleted >= 4)
        {
            StartCoroutine(waitForCredits(5));
            if (startCredits)
            {
                StartCoroutine(DisplayCredits(45));
                startCredits = false;
            }
        }
    }

    public void ShowSettings()
    {
        mainMenuUI.SetActive(false);
        audioSettingsUI.SetActive(true);
    }
    public void LeaveSettings()
    {
        mainMenuUI.SetActive(true );
        audioSettingsUI.SetActive(false);
    }
    public void ShowSettingInGame()
    {
        audioSettingsUI.SetActive(true) ;
        pauseMenuUI.SetActive(false) ;
    }
    public void LeaveSettingInGame()
    {
        audioSettingsUI.SetActive(false) ;
        pauseMenuUI.SetActive(true) ;
    }

    public void handlePause()
    {
        if ((Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.P)) && SceneManager.GetActiveScene().buildIndex != 0 )
        {
            if (!isPuased)
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                isPuased = true;
                if (heroDialogUI.activeSelf)
                {
                    heroDialogUI.SetActive(false);
                    heroActive = true;
                }
                else if (builderDialogUI.activeSelf)
                {
                    builderDialogUI.SetActive(false);
                    builderActive = true;
                }
                else if (blacksmithDialogUI.activeSelf)
                {
                    blacksmithDialogUI.SetActive(false);
                    blacksmithActive = true;
                }
                else if (princeDialogUI.activeSelf)
                {
                    princeDialogUI.SetActive(false);
                    princeActive = true;
                }
            }
            else
            {
                if (!audioSettingsUI.activeSelf )
                {
                    pauseMenuUI.SetActive(false);
                    if (!isCurrentlyInDialog)
                    {
                        Time.timeScale = 1;
                        Cursor.visible = false;
                        Cursor.lockState = CursorLockMode.Locked;
                    }
                    isPuased = false;
                    if (heroActive)
                    {
                        heroDialogUI.SetActive(true);
                        heroActive = false;
                    }
                    else if (builderActive)
                    {
                        builderDialogUI.SetActive(true);
                        builderActive = false;
                    }
                    else if (blacksmithActive)
                    {
                        blacksmithDialogUI.SetActive(true);
                        blacksmithActive = false;
                    }
                    else if (princeActive)
                    {
                        princeDialogUI.SetActive(true);
                        princeActive = false;
                    }
                }
            }
        }
    }
    public void BackToGame()
    {
        if (!audioSettingsUI.activeSelf)
        {
            pauseMenuUI.SetActive(false);
            if (!isCurrentlyInDialog)
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            isPuased = false;
            if (heroActive)
            {
                heroDialogUI.SetActive(true);
                heroActive = false;
            }
            else if (builderActive)
            {
                builderDialogUI.SetActive(true);
                builderActive = false;
            }
            else if (blacksmithActive)
            {
                blacksmithDialogUI.SetActive(true);
                blacksmithActive = false;
            }
            else if (princeActive)
            {
                princeDialogUI.SetActive(true);
                princeActive = false;
            }
        }
    }
    IEnumerator DisplayCredits(float time)
    {
        Time.timeScale = 0;
        CreditsUI.SetActive(true);
        float elapedTime = 0f;
        audioManager.Play("Horn");
        audioManager.Play("War");
        audioManager.StopPlaying("Footsteps");
        while (elapedTime < time)
        {
            creditsPOS.position = Vector3.Lerp(creditsBegin.position, creditsEnd.position, (elapedTime / time));
            elapedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        creditsEnd.position = creditsEnd.position;
        SceneManager.LoadScene(0);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    IEnumerator waitForCredits(float time)
    {
        yield return new WaitForSeconds(time);
        startCredits = true;
    }
}
