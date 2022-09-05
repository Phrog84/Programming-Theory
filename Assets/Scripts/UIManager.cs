using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public int _enemiesToDefeat = 50;

    public Text _enemiesDefeatedText;

    public Text gameOverText;
    public Text restartText;

    public Sprite[] _livesSprites;
    public Image _LivesImg;

    public Sprite[] _shotsRemaining;
    public Image _shotsImg;


    private void Start()
    {
        _enemiesDefeatedText.text = _enemiesToDefeat.ToString();
        gameOverText.gameObject.SetActive(false);
        //gameOverText.gameObject.GetComponent<Outline>();
    }

    public void UpdateEneimesDefeated(int EnemiesDefeated)
    {
        _enemiesDefeatedText.text = EnemiesDefeated.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite = _livesSprites[currentLives];
    }

    public void UpdateShots(int currentShots)
    {
        _shotsImg.sprite = _shotsRemaining[currentShots];
    }

    public void GameOverText()
    {
        gameOverText.gameObject.SetActive(true);
        StartCoroutine(GameOverTextFlickerRoutine());
        StartCoroutine(RestartGame());
    }

    IEnumerator GameOverTextFlickerRoutine()
    {
        while (true)
        {
            gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(.05f);
            gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator RestartGame()
    {
        while (true)
        {
            yield return new WaitForSeconds(.75f);
            restartText.gameObject.SetActive(true);
        }
    }
}
