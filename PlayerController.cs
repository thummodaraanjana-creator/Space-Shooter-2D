using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 15f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1*Time.deltaTime*speed, 0, 0));
    }
}
