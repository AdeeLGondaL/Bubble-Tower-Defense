using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private Joystick joystick;
    private Tween tweenID;
    public float moveSpeed;
    public float currentRotateAngleHorizontal, currentRotateAngleVertical;

    public float maxRotateAngleHorizontal, minRotateAngleHorizontal, maxRotateAngleVertical, minRotateAngleVertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Direction.x < 0 && currentRotateAngleHorizontal > minRotateAngleHorizontal)
        {
            currentRotateAngleHorizontal += joystick.Direction.x;
            tweenID = transform.DORotate( new Vector3(0, currentRotateAngleHorizontal, currentRotateAngleVertical), 0f);
        } 
        else if (joystick.Direction.x > 0 && currentRotateAngleHorizontal < maxRotateAngleHorizontal)
        {
            currentRotateAngleHorizontal += joystick.Direction.x;
            tweenID = transform.DORotate( new Vector3(0, currentRotateAngleHorizontal, currentRotateAngleVertical), 0f);
        }
        if (joystick.Direction.y < 0 && currentRotateAngleVertical < maxRotateAngleVertical)
        {
            currentRotateAngleVertical += -joystick.Direction.y;
            tweenID = transform.DORotate( new Vector3(0, currentRotateAngleHorizontal, currentRotateAngleVertical), 0f);
        } 
        else if (joystick.Direction.y > 0 && currentRotateAngleVertical > minRotateAngleVertical)
        {
            currentRotateAngleVertical -= joystick.Direction.y;
            tweenID = transform.DORotate( new Vector3(0, currentRotateAngleHorizontal, currentRotateAngleVertical), 0f);
        }
    }
}
