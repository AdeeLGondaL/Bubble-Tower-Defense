using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private Joystick joystick;
    private Tween tweenID;
    public int currentRotateAngleY, currentRotateAngleX;

    public int maxRotateAngleY, minRotateAngleY, maxRotateAngleX, minRotateAngleX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Direction.x < 0 && currentRotateAngleY < 30f)
        {
            tweenID = transform.DORotate( new Vector3(currentRotateAngleX, 0f, currentRotateAngleY++), 0f);
        } 
        else if (joystick.Direction.x > 0 && currentRotateAngleY > -30f)
        {
            tweenID = transform.DORotate( new Vector3(currentRotateAngleX, 0f, currentRotateAngleY--), 0f);
        }
        if (joystick.Direction.y < 0 && currentRotateAngleX < 110f)
        {
            tweenID = transform.DORotate( new Vector3(currentRotateAngleX++, 0f, currentRotateAngleY), 0f);
        } 
        else if (joystick.Direction.y > 0 && currentRotateAngleX > 85f)
        {
            tweenID = transform.DORotate( new Vector3(currentRotateAngleX--, 0f, currentRotateAngleY), 0f);
        }
    }
}
