using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private float _destroyYPosition = 8f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > _destroyYPosition)
        {
            Destroy(gameObject);
        }
    }
}