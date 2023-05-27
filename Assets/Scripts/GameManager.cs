using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;
    public Text scoreText;
    public Image[] life;
    public int lives = 3;
    public float respawnTime = 3.0f;
    public float respawnInvulnerablityTime = 3.0f;
    public int score = 0;
    

    public void AsteroidDestroyed(Asteroid asteroid)
    {
       this.explosion.transform.position = asteroid.transform.position;
       this.explosion.Play();

       if(asteroid.size < 0.75f)
       {
        score +=25;
        scoreText.text = "" + score;
       }
       else if(asteroid.size <1.25f)
       {
         score +=50;
         scoreText.text = "" + score;
       }
       else
       {
         score +=100;
         scoreText.text = "" + score;
       }
       
    }

    public void PlayerDied()
    {
       this.explosion.transform.position = this.player.transform.position;
       this.explosion.Play();
       this.lives--;
       Destroy(life[lives].gameObject);
       if(this.lives ==0)
       {
          GameOver();
       }
       else
       {
        Invoke(nameof(Respawn), this.respawnTime);
       } 
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);
        
        Invoke(nameof(TurnOnCollisions),this.respawnInvulnerablityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
        this.lives = 3;
        this.score = 0;
    }
}
