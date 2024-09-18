using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Dialog : MonoBehaviour
{
    [TextArea(4,10)][SerializeField] public string[] sentences;

    
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject dialogMenu;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject endDialogButton;

    [SerializeField] GameObject pcSprite;
    [SerializeField] GameObject npcSprite;

    [SerializeField] AudioManager audioManager;

    bool lastLineRead = false;
    bool isItalizized = false;
    public enum characterSpeaking{
    pc,
    npc,
    narrator
    }

    [SerializeField] public characterSpeaking[] characterToSpeak;

    private int sentenceToRead;
    private void Awake()
    {
        sentenceToRead = 0;
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void DialogTextUpdate()
    {
        dialogMenu.SetActive(true);
        endDialogButton.SetActive(false);
        GameManager.Instance.isCurrentlyInDialog = true;
        if (characterToSpeak[sentenceToRead] == characterSpeaking.pc)
        {
            pcSprite.GetComponent<Image>().color = Color.white;
            npcSprite.GetComponent<Image>().color = Color.grey;
            isItalizized = false;
        }
        else if (characterToSpeak[sentenceToRead] == characterSpeaking.npc) 
        {
            pcSprite.GetComponent<Image>().color = Color.grey;
            npcSprite.GetComponent<Image>().color = Color.white;
            isItalizized = false;
        }
        else if (characterToSpeak[sentenceToRead] == characterSpeaking.narrator) 
        {
            pcSprite.GetComponent<Image>().color = Color.grey;
            npcSprite.GetComponent<Image>().color = Color.grey;
            if (!lastLineRead)
            {
                isItalizized = true;
            }
        }
        if (sentenceToRead + 1 < sentences.Length)
        {
            StopAllCoroutines();
            StartCoroutine(TypeText(sentences[sentenceToRead]));
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(TypeText(sentences[sentenceToRead]));
            continueButton.SetActive(false);
            endDialogButton.SetActive (true);
        }


    }

    public void ContinueButtonClick() 
    {
        audioManager.StopPlaying("writing");
        sentenceToRead++;
        DialogTextUpdate();
    }

    IEnumerator TypeText(string type)
    {
        audioManager.Play("writing");
        text.text = "";
        if (isItalizized)
        {
            text.text += "<i>";
        }
        foreach (char c in type.ToCharArray())
        {
            text.text += c;
            yield return new WaitForSecondsRealtime(.07f);
        }
        if (isItalizized)
        {
            text.text += "</i>";
        }
        audioManager.StopPlaying("writing");
    }

    public void EndDialog()
    {
        audioManager.StopPlaying("writing");
        if (!lastLineRead)
        {
            GameManager.Instance.CharactersConvosCompleted++;
        }
        lastLineRead = true;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.Instance.isCurrentlyInDialog = false;
        dialogMenu.SetActive(false);
    }

}
