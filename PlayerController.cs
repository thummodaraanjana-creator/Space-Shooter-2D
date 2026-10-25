using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1*Time.deltaTime*5, 0, 0));
    }
}
