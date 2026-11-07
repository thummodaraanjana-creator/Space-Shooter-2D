using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.4f;
    public int powerupID; //0 = triple shot, 1 = speed boost, 2 = shield
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
                if (powerupID == 0)
                {
                    player.StartCoroutine(player.TripleShotPowerupRoutine());
                }//activate triple shot powerup
                else if (powerupID == 1)
                {
                    player.StartCoroutine(player.SpeedBoostPowerupRoutine());
                }//activate speed boost powerup
                else if(powerupID == 2) 
                {
                    player.EnableShield();

                }//active shield boost powerup
            }
           

            //destroy powerup
            Destroy(gameObject);
        }
       
    }
}
