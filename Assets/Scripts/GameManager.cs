using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int _enemiesRemaining;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI resultText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemiesRemaining = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        UpdateCounter();

    }

    public void EnemyDied(){
        _enemiesRemaining --;

        if (_enemiesRemaining == 0){
            PlayerWon();
        }
        UpdateCounter();
    }

    public void PlayerDied(){
        Debug.Log("You lost");
        resultText.gameObject.SetActive(true);
        resultText.text = "You lost";
    }

    public void PlayerWon(){
        Debug.Log("You Won");
        resultText.gameObject.SetActive(true);
        resultText.text = "You Won";

    }

    public void UpdateCounter(){
        countText.text = "Enemies: " + _enemiesRemaining;
    }
}
