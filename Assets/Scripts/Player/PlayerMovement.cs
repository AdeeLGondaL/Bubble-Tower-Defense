using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    [SerializeField] private Joystick joystick;
    private Tween tweenID;
    private int rotateAngle = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Direction.x < 0 && rotateAngle < 30f)
        {
            tweenID = transform.DORotate( new Vector3(90f, 0f, rotateAngle++), 0f);
        } 
        else if (joystick.Direction.x > 0 && rotateAngle > -30f)
        {
            tweenID = transform.DORotate( new Vector3(90f, 0f, rotateAngle--), 0f);
        }
    }
}
