using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int _enemiesRemaining;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI resultText;
    private bool _gameOver = false;
    public bool isGameOver => _gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemiesRemaining = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        UpdateCounter();
        Time.timeScale = 1;

    }

    public void EnemyDied(){
        _enemiesRemaining --;

        if (_enemiesRemaining == 0){
            PlayerWon();
        }
        UpdateCounter();
    }

    public void PlayerDied(){
        if (_gameOver == true){
            return;
        }
        _gameOver = true;
        Debug.Log("You lost");
        resultText.gameObject.SetActive(true);
        resultText.text = "You lost";
        Time.timeScale = 0;
        CursorState();
    }

    public void PlayerWon(){
         if (_gameOver == true){
            return;
        }
        _gameOver = true;
        Debug.Log("You Won");
        resultText.gameObject.SetActive(true);
        resultText.text = "You Won";
        Time.timeScale = 0;
        CursorState();
    }

    public void UpdateCounter(){
        countText.text = "Enemies: " + _enemiesRemaining;
    }

    public void CursorState(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
