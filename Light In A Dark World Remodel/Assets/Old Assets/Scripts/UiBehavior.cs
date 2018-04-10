using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiBehavior : MonoBehaviour {
    public GameObject pause;
    public GameObject gameOver;
    public GameObject panel;
    public GameObject player;
    public GameObject continueButton;
    public GameObject levelCom;
    public GameObject lvlPanel;
    public GameObject playAgain;
    public Text gameOverText;
    public float moveText;
    public float dropSpeed;
    public int newScore;
    public int timeScore;
    public float timer;
    public Text finalScore;
    public GameObject scoreDisplay;
    public Text timerDisplay;
    public PlayerMove score;


	void Start ()
    {
        panel.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
        gameOverText.canvasRenderer.SetAlpha(0f);
        lvlPanel.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
    }
	
	void Update ()
    {
        timer = Time.timeSinceLevelLoad;
        timerDisplay.text = timer.ToString("F2");
        Debug.Log(lvlPanel.GetComponent<Image>().canvasRenderer.GetAlpha());
        if(Time.timeScale == 0)
        {
            if(timer < 10)
            {
                timeScore = 4;
            }
            if(timer < 20 && timer > 10)
            {
                timeScore = 3;
            }
            if(timer < 30 && timer > 20)
            {
                timeScore = 2;
            }
            if(timer > 30)
            {
                timeScore = 1;
            }
            newScore = score.finalScore * timeScore - Mathf.RoundToInt(timer);
        }
		if(Input.GetButtonDown("Cancel"))
        {
            if(pause.activeSelf)
            {
                pause.SetActive(false);
            }
            else
            {
                pause.SetActive(true);
            }
        }
        if(pause.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        if(gameOver.activeSelf)
        {
            panel.GetComponent<Image>().CrossFadeAlpha(1.0f, 0.5f, true);
        }
        if(!player.activeSelf)
        {
            gameOver.SetActive(true);
        }
        if (panel.GetComponent<Image>().canvasRenderer.GetAlpha() > 0.9f)
        {
            moveText -= 1 * dropSpeed * Time.deltaTime;
            gameOverText.rectTransform.position = new Vector3(gameOverText.rectTransform.position.x, moveText);
            if (gameOverText.rectTransform.position.y < 260f)
            {
                gameOverText.CrossFadeAlpha(1.0f, 5.0f, true);
            }
            if(gameOverText.rectTransform.position.y < 210f && dropSpeed > 0)
            {
                dropSpeed -= 5.0f * Time.deltaTime;
            }
            if(dropSpeed < 0)
            {
                dropSpeed = 0f;
            }
            if(dropSpeed == 0)
            {
                StartCoroutine(ActivateButton());
            }
        }
        if (levelCom.activeSelf)
        {
            Time.timeScale = 0f;
            if (Time.timeScale == 0)
            {
                StartCoroutine(DimBackground());
            }
        } 
	}
    IEnumerator DimBackground()
    {
        if (Time.timeScale == 0)
        {
            yield return new WaitForSecondsRealtime(1);
            if (lvlPanel.GetComponent<Image>().canvasRenderer.GetAlpha() < 0.4f)
            {
                lvlPanel.GetComponent<Image>().CrossFadeAlpha(1.0f, 0.5f, true);
            }
        }
        if(lvlPanel.GetComponent<Image>().canvasRenderer.GetAlpha() >= 0.4f)
        {
            yield return new WaitForSecondsRealtime(1.5f);
            scoreDisplay.SetActive(true);
            finalScore.text = newScore.ToString();
        }
        yield return new WaitForSecondsRealtime(1f);
        if(scoreDisplay.activeSelf)
        {
            playAgain.SetActive(true);
        }
    }
    IEnumerator ActivateButton()
    {
        yield return new WaitForSeconds(1);
        continueButton.SetActive(true);
    }
    public void Resume()
    {
        pause.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Proto");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseButton()
    {
        pause.SetActive(true);
    }
}
