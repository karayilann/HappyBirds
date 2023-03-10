using UnityEngine;
using UnityEngine.SceneManagement;

public class menuCodes : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject GeneralPanel;
    public void PlayButton()
    {
        GeneralPanel.SetActive(false);
        SceneManager.LoadScene("Level1");
    }

    

}
