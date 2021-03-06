using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Animator animator;

    public GameObject screenParent;
    public GameObject scoreParent;
    public GameObject loseParent;
    public GameObject winParent;
    public GameObject game;

    public TMP_Text score;
    public GameObject[] stars;

    void Start()
    {
        foreach (GameObject star in stars)
        {
            star.SetActive(false);
        }

        loseParent.SetActive(false);
        winParent.SetActive(false);
        screenParent.SetActive(false);
        game.SetActive(true);
    }

    public void ShowLose(int _score, int starCount)
    {
        game.SetActive(false);
        screenParent.SetActive(true);
        winParent.SetActive(false);
        loseParent.SetActive(true);

        score.text = _score.ToString();
        score.enabled = false;

        if (animator)
        {
            animator.Play("GameOverShow");
        }
        StartCoroutine(ShowStartsCorutine(starCount));
    }

    public void ShowWin(int _score, int starCount)
    {
        game.SetActive(false);
        screenParent.SetActive(true);
        loseParent.SetActive(false);
        winParent.SetActive(true);

        score.text = _score.ToString();
        score.enabled = false;

        if (animator)
        {
            animator.Play("GameOverShow");
        }
        StartCoroutine(ShowStartsCorutine(starCount));
    }

    private IEnumerator ShowStartsCorutine(int starCount)
    {
        yield return new WaitForSeconds(0.5f);

        if (starCount < stars.Length)
        {
            for (int i = 0; i < starCount; i++)
            {
                stars[i].SetActive(true);
            }
        }
        score.enabled = true;
    }

    public void OnReplayClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnDoneClicked()
    {
        SceneManager.LoadScene(0);
    }
    public void OnNextLevelClicked()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);
    }
}
