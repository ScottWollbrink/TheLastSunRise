using UnityEngine;

public class Triggerdialog : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    [SerializeField] GameObject textbutton;

    bool triggerentered = false;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && triggerentered)
        {
            textbutton.SetActive(false);
            dialog.DialogTextUpdate();

            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            
            if (collision.gameObject.layer != 3)
            {
            triggerentered = true;
            textbutton.SetActive(true);
            }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 3)
        {
            triggerentered = false;
            textbutton.SetActive(false);
        }
    }

}
