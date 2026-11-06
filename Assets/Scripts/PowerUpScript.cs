using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.4f;
    private void Start()
    {
        
    }

    
    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            //access player
            PlayerController player = target.GetComponent<PlayerController>();

            if (player != null)
            {
                //turn on isTripleShotActive true
                player.isTripleShotActive = true;
            }
            player.StartCoroutine(player.TripleShotPowerupRoutine());

            //destroy powerup
            Destroy(gameObject);
        }
       
    }
}
