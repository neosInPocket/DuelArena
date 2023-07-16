using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public abstract class PlayerTouchControl : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    private Finger movementFinger;
    protected Vector2 movementAmount;

    private void Start()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        Execute();
    }
    protected abstract void Initialize();
    protected abstract void Execute();

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        Touch.onFingerDown += OnFingerDown;
        Touch.onFingerUp += OnFingerUp;
        Touch.onFingerMove += OnFingerMove;
    }

    private void OnDisable()
    {
        Touch.onFingerDown -= OnFingerDown;
        Touch.onFingerUp -= OnFingerUp;
        Touch.onFingerMove -= OnFingerMove;
        EnhancedTouchSupport.Disable();
    }

    private void OnFingerMove(Finger finger)
    {
        if (finger == movementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = joystick.JoystickSize.x / 2f;
            Touch currentTouch = finger.currentTouch;

            if (joystick.RectTransform == null)
            {
                return;
            }
            
            if (Vector2.Distance(
                    currentTouch.screenPosition,
                    joystick.RectTransform.anchoredPosition
                ) > maxMovement)
            {
                knobPosition = (
                    currentTouch.screenPosition - joystick.RectTransform.anchoredPosition
                    ).normalized
                    * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - joystick.RectTransform.anchoredPosition;
            }

            joystick.Knob.anchoredPosition = knobPosition;
            movementAmount = knobPosition / maxMovement;
        }
    }

    private void OnFingerUp(Finger finger)
    {
        if (finger == movementFinger)
        {
            if (joystick.RectTransform == null)
            {
                return;
            }
            
            movementFinger = null;
            joystick.Knob.anchoredPosition = Vector2.zero;
            joystick.gameObject.SetActive(false);
            movementAmount = Vector2.zero;
        }
    }

    private void OnFingerDown(Finger finger)
    {
        if (joystick.RectTransform == null)
        {
            return;
        }

        if (joystick.IsRightScreen && (movementFinger == null && finger.screenPosition.x <= Screen.width / 2f))
        {
            return;
        }

        if (!joystick.IsRightScreen && !(movementFinger == null && finger.screenPosition.x <= Screen.width / 2f))
        {
            return;
        }

        movementFinger = finger;
        movementAmount = Vector2.zero;
        joystick.gameObject.SetActive(true);
        joystick.RectTransform.sizeDelta = joystick.JoystickSize;
        joystick.RectTransform.anchoredPosition = finger.screenPosition;
    }
}
