using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public float boardSpeed;
    void Start()
    {
    }

    void Update()
    {
        BoardMove();
    }
    private void BoardMove()
    {
        float x = Input.GetAxis("Horizontal") * boardSpeed;
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, transform.position.y);
        transform.position = ClampX(-2.5f, 2.5f);
    }
    private Vector2 ClampX(float min, float max)
    {
        Vector2 result = new Vector2(Mathf.Clamp(transform.position.x, min, max), transform.position.y);

        return result;
    }
}
