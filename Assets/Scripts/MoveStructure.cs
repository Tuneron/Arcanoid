using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStructure : MonoBehaviour
{

    // Use this for initialization
    public float Speed;
    public float FirsBound;
    public float SecondBound;
    public bool Horizontal = true;
    private bool Inverse = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Inverse)
        {
            if (FirsBound >= 0)
            {
                if (GetCoordinate(Horizontal) < FirsBound)
                    Move(!Inverse, Horizontal);
                else
                    Inverse = !Inverse;

            }
            else
            {
                if (GetCoordinate(Horizontal) > FirsBound)
                    Move(Inverse, Horizontal);
                else
                    Inverse = !Inverse;
            }
        }
        else
        {
            if (FirsBound >= 0)
            {
                if (GetCoordinate(Horizontal) > SecondBound)
                    Move(!Inverse, Horizontal);
                else
                    Inverse = !Inverse;

            }
            else
            {
                if (GetCoordinate(Horizontal) < SecondBound)
                    Move(Inverse, Horizontal);
                else
                    Inverse = !Inverse;
            }
        }
    }

    private void Move(bool direction, bool axis)
    {
        if (axis)
        {
            if (direction)
                transform.Translate(new Vector3(1f, 0f, 0f) * Speed);
            else
                transform.Translate(-new Vector3(1f, 0f, 0f) * Speed);
        }
        else
        {
            if (direction)
                transform.Translate(new Vector3(0f, 1f, 0f) * Speed);
            else
                transform.Translate(-new Vector3(0f, 1f, 0f) * Speed);
        }
    }

    private float GetCoordinate(bool axis)
    {
        if (axis)
            return transform.position.x;
        else
            return transform.position.y;
    }
}
