using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControllerr : MonoBehaviour
{
    [SerializeField] private RectTransform joystickOutline;
    [SerializeField] private RectTransform joystickButton;
    [SerializeField] private float moveFactor;

    private Vector3 move;

    private bool joystickKapaliA�ik;
    private Vector3 topPosition;


    void Start()
    {
        JoystickSakla();
    }

    // Update is called once per frame
    

    public void EkranaDokunma()
    {
        topPosition = Input.mousePosition;
        joystickOutline.position = topPosition;

        JoystickG�ster();
       

    }

    private void JoystickG�ster()
    {
        joystickOutline.gameObject.SetActive(true);
        joystickKapaliA�ik = true;

    }
    private void JoystickSakla()
    {
        joystickOutline.gameObject.SetActive(false);
        joystickKapaliA�ik = false;
        move = Vector3.zero;

    }

    public void JoystickControl()
    {
        Vector3 currentPosition = Input.mousePosition;
        Vector3 direction = currentPosition - topPosition;

        float canvasYScale = GetComponentInParent<Canvas>().GetComponent<RectTransform>().localScale.y;
        float moveMagnitude = direction.magnitude * moveFactor * canvasYScale;

        float joystickYariAlan = joystickOutline.rect.width / 2;
        float newWidth = joystickYariAlan * canvasYScale;

        moveMagnitude = Mathf.Min(moveMagnitude, newWidth);
        move = direction.normalized * moveMagnitude;

        Vector3 targetPosition = topPosition + move;
        joystickButton.position = targetPosition;

        if (Input.GetMouseButtonUp(0))
        {
            JoystickSakla();
        }
    }
    public Vector3 GetMoviePosition()
    {
        return move / 1.75f;  
    }

    void Update()
    {
        if (joystickKapaliA�ik)
        {
            JoystickControl();
        }
    }
}

