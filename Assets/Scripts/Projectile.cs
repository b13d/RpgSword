using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public LineRenderer line;
    void Start()
    {
        line.startWidth = .2f;
        line.endWidth = .2f;
        line.positionCount = 2;
    }

    void Update()
    {

        Vector2 currentPoint = GetWorldCoordinate(Input.mousePosition);
        line.SetPosition(line.positionCount - 2, transform.position);
        line.SetPosition(line.positionCount - 1, currentPoint);




    }

    Vector2 GetWorldCoordinate(Vector3 mousePosition)
    {
        Vector2 mousePoint = new Vector3(mousePosition.x, mousePosition.y, 1);
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
