using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBoard : MonoBehaviour
{
    public float Speed;
    public float boardSize;
    void Start()
    {
    }

    void Update()
    {
        transform.Translate(new Vector2(Speed * Time.deltaTime,0));
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("벽에 박음!!");
            Speed *= -1;
        }
    }
}
