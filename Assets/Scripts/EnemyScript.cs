using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float _speed = 4f;
    private void Start()
    {
        
    }

    
    void Update()
    {
        //move down at a speed of 4
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        //if bottom of screen, respawn at top with random x position
        if (transform.position.y <= -8f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 8f, 0);

        }
    }
}
