using UnityEngine;
using System.Collections;



public class PlayerController : MonoBehaviour
{
    public bool isTripleShotActive = false;
    public bool hasSpeedBoostActive = false;
    public bool hasShieldActive = false;
    public GameObject laserPrefab;
    public GameObject tripleShotPrefab;
    public GameObject shieldVisualizer;
    [SerializeField]private float _speed = 15f;

    [SerializeField]
    private GameObject _playerExplosionPrefab;

    private UIManager _uiManager;

    public GameObject _gameOverScreen;

    private AudioSource _audioSource;


    public int _life = 3;


    private void Start()
    {
        _gameOverScreen.SetActive(false);
        hasShieldActive = false;
        shieldVisualizer.SetActive(false);

        _audioSource = GetComponent<AudioSource>();
        

        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (_uiManager != null)
        {
            _uiManager.UpdateLives(_life);
        }
    }//start

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();

        PlayerBounds();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerShoot();
        }


    }//update

    private void PlayerMovement()
    {
        //player powerup movement
        if (hasSpeedBoostActive == true)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right *5* _speed * Time.deltaTime * horizontalInput);
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up *5* _speed * Time.deltaTime * verticalInput);
        }
        //player normal movement
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * _speed * Time.deltaTime * horizontalInput);
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * _speed * Time.deltaTime * verticalInput);
        }
       
    }//player movement

    private void PlayerBounds()
    {
        if (transform.position.x >= 8)
        {
            transform.position = new Vector3(8, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -8)
        {
            transform.position = new Vector3(-8, transform.position.y, transform.position.z);
        }
        if (transform.position.y <= -4f)
        {
            transform.position = new Vector3(transform.position.x, -4, transform.position.z);
        }
        else if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }//player bounds

    public void Damage()
    {
        if(hasShieldActive == true)
        {
            hasShieldActive = false;
            shieldVisualizer.SetActive(false);
            return;
        }
        _life--;
        _uiManager.UpdateLives(_life);
        if (_life == 0)
        {
            Instantiate(_playerExplosionPrefab, transform.position, Quaternion.identity);
            _gameOverScreen.SetActive(true);
            Destroy(gameObject);
        }
    }//Damage

    private void PlayerShoot()
    {
        _audioSource.Play();
        if (isTripleShotActive == true)
        {
            //spawn triple shot
            Instantiate(tripleShotPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
         }
        else
        {
            //spawn single shot
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        } 
    } //player shoot

    
    public IEnumerator TripleShotPowerupRoutine()
    {
        isTripleShotActive = true;
        yield return new WaitForSeconds(5f);
        isTripleShotActive = false;
    }//powerup coroutine for triple shot

    public IEnumerator SpeedBoostPowerupRoutine()
    {
        hasSpeedBoostActive = true;
        yield return new WaitForSeconds(5f);
        hasSpeedBoostActive = false;
    }//powerup coroutine for speed boost

    public void EnableShield()
    {
        hasShieldActive = true;
        shieldVisualizer.SetActive(true);

    }//isSheildActive
}//class
    