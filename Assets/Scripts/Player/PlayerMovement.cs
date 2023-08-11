using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private Joystick joystick;
    private Tween tweenID;
    private int rotateAngleY = 0, rotateAngleX = 90;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Direction.x < 0 && rotateAngleY < 30f)
        {
            tweenID = transform.DORotate( new Vector3(rotateAngleX, 0f, rotateAngleY++), 0f);
        } 
        else if (joystick.Direction.x > 0 && rotateAngleY > -30f)
        {
            tweenID = transform.DORotate( new Vector3(rotateAngleX, 0f, rotateAngleY--), 0f);
        }
        if (joystick.Direction.y < 0 && rotateAngleX < 110f)
        {
            tweenID = transform.DORotate( new Vector3(rotateAngleX++, 0f, rotateAngleY), 0f);
        } 
        else if (joystick.Direction.y > 0 && rotateAngleX > 85f)
        {
            tweenID = transform.DORotate( new Vector3(rotateAngleX--, 0f, rotateAngleY), 0f);
        }
    }
}
