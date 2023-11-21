using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{
    public GameObject InGamePanel;
    public GameObject FinishPanel;

    


    void Start()
    {

        Cursor.visible = false;
    }

    

    public void Exit()
    {
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
       
    }
    public void Finish()
    {
        InGamePanel.SetActive(false);
        FinishPanel.SetActive(true);
        
    }
    public void Return_Game()
    {
        InGamePanel.SetActive(false);
    }
    public void MainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }
    public void Restart_Game()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MenuButtonOnClick()
    {
        FinishPanel.SetActive(false);
        InGamePanel.SetActive(true);
    }


}
