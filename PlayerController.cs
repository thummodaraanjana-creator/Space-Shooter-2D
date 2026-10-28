using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    public float horizontalInput;

    public float verticalInput;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime*horizontalInput);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * Time.deltaTime * verticalInput);
    }
}
