using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelContorller : MonoBehaviour
{
    public List<GridController> allGrid;
    [SerializeField] private GameObject winText;
    [SerializeField] private Text levelText;

    void Start()
    {
        levelText.text = SceneManager.GetActiveScene().name;
    }

    public void CheckWin()
    {
        if (allGrid.Count <= 0)
            StartCoroutine(Win());
    }

    public void RemoveGridFromList(GridController grid)
    {
        allGrid.Remove(grid);
    }

    IEnumerator Win()
    {
        winText.SetActive(true);
        yield return new WaitForSeconds(1);
        LoadNextScene();
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void LoadNextScene()
    {
        int levelNumber = int.Parse(SceneManager.GetActiveScene().name.Split(' ')[1]);
        if (levelNumber >= 8)
            SceneManager.LoadScene("Level " + 1);
        else
            SceneManager.LoadScene("Level " + (int)(levelNumber + 1));

    }

}
