using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 startPosition;
    public float length = 5f;
    public float timeLength = 10f;
    public MovingType type = MovingType.LeftToRight;
    private float currentTime = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (gameObject.activeInHierarchy)
            collision.collider.transform.SetParent(null);
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;
        if (currentTime > timeLength)
        {
            currentTime -= timeLength;
        }

        var normal = (Mathf.Sin((currentTime / timeLength) * Mathf.PI * 2f) + 1f) / 2f;
        
        normal *= length;
        switch (type)
        {
            case MovingType.LeftToRight:
                transform.position = startPosition + Vector3.right * normal;
                break;
            case MovingType.RightToLeft:
                transform.position = startPosition + Vector3.left * normal;
                break;
            case MovingType.DownToUp:
                transform.position = startPosition + Vector3.up * normal;
                break;
            case MovingType.UpToDown:
                transform.position = startPosition + Vector3.down * normal;
                break;
        }
    }
}

public enum MovingType
{
    LeftToRight,
    RightToLeft,
    DownToUp,
    UpToDown,
}
