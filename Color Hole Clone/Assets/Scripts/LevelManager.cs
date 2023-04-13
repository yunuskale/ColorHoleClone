using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject[] Levels = new GameObject[2];
    public int currentLevelNumber = 0;
    public GameObject currentlevel;
    public Text levelText;

    public void Start()
    {
        LevelText();
        currentlevel = Instantiate(Levels[0]);
    }

    public void NextLevel()
    {
        Destroy(currentlevel);
        currentLevelNumber++;
        if (currentLevelNumber > Levels.Length - 1)
        {
            currentLevelNumber = 0;
        }
        currentlevel = Instantiate(Levels[currentLevelNumber]);
        StartCoroutine(Restart());
        LevelText();
    }
    public void RestartLevel()
    {
        Destroy(currentlevel);
        currentlevel = Instantiate(Levels[currentLevelNumber]);
        StartCoroutine(Restart());
        LevelText();

    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1f);
        Object.FindObjectOfType<GameManager>().Restart();
    }

    void LevelText()
    {
        levelText.text = "LEVEL " + (currentLevelNumber+1).ToString();
    }
}
