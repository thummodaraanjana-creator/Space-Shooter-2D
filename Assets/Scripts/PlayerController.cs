using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isTripleShotActive = false;
    public GameObject laserPrefab;
    public GameObject tripleShotPrefab;
    [SerializeField]private float _speed = 15f;
    

    private void Start()
    {

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
       float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * _speed * Time.deltaTime * horizontalInput);
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * _speed * Time.deltaTime * verticalInput);
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

    private void PlayerShoot()
    {
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
}//class
    