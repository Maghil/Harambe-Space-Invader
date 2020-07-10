using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text scoreBoard;
    public int health=1;
    public bool invincible;

    protected int score = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        if (health < 1)
        {
            Debug.LogError("healh too low");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth()
    {
        if (!invincible) {
            if (health > 1 ) 
            {
                health -= 1;
            }
            else
            {
                GameOver();
            }
        }
    }

    public void EnemyScore()
    {
        score+=10;
        string s = string.Format("Score : {0:000}", score);
        scoreBoard.text = s;

    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public int Score
    {
        get { return score; }
    }
     
    public bool Invincible
    {
        set { invincible=value; }
    }
}



