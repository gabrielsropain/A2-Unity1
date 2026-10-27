using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _enemiesRemaining;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemiesRemaining = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDied(){
        _enemiesRemaining --;

        if (_enemiesRemaining == 0){
            PlayerWon();
        }
    }

    public void PlayerDied(){
        Debug.Log("Perdiste");
    }

    public void PlayerWon(){
        Debug.Log("Ganaste");
    }
}
