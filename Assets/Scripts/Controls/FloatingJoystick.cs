using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]
public class FloatingJoystick : MonoBehaviour
{
    [SerializeField] private Vector2 joystickSize = new Vector2(150, 150);
    [SerializeField] private bool isRightScreen;

    [HideInInspector] public RectTransform RectTransform;
    public Vector2 JoystickSize => joystickSize;
    public bool IsRightScreen => isRightScreen;
    public RectTransform Knob;
    

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }
}
