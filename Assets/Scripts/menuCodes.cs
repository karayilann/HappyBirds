using UnityEngine;
using UnityEngine.SceneManagement;

public class menuCodes : MonoBehaviour
{
    public GameObject SettingsPanel;            // settings screen
    public GameObject GeneralPanel;             // menu screen panel
    public GameObject CreditsPanel;             // Credits screen
    
    public void PlayButton()
    {
        GeneralPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        SceneManager.LoadScene("Level1");
    }
    
    public void SettingsButton()
    {
        GeneralPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }
    
    public void CreditsButton()
    {
        GeneralPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }
    
    public void BackButton()
    {
        GeneralPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void LikeButton()
    {
        Application.OpenURL("https://linktr.ee/muhammetkarayilan");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
