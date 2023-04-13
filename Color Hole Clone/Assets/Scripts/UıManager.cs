using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UıManager : MonoBehaviour
{
    public GameObject failedPanel, winPanel;
    public Image bar1, bar2;

    public void Failed()
    {
        GameManager.finish = true;
        failedPanel.SetActive(true);
    }
    public void Win()
    {
        winPanel.SetActive(true);
    }
    public void TryAgain()
    {
        bar1.fillAmount = 0; bar2.fillAmount = 0;
        failedPanel.SetActive(false);     
        Object.FindObjectOfType<LevelManager>().RestartLevel();
    }
    public void Next()
    {
        bar1.fillAmount = 0; bar2.fillAmount = 0;
        winPanel.SetActive(false);     
        Object.FindObjectOfType<LevelManager>().NextLevel();
    }
}
