using UnityEngine;

public class OnKeyPressTrigger : ScriptableEventTrigger
{

    [Header("Key Press Trigger")]
    public KeyPressType PressType;
    public KeyCode Key;

    private void Update()
    {
        CheckKeyPresses();
    }

    void CheckKeyPresses()
    {
        switch (PressType)
        {
            case KeyPressType.Down:
                HandleKeyDown();
                break;

            case KeyPressType.Up:
                HandleKeyUp();
                break;

            case KeyPressType.Hold:
                HandleKeyHeld();
                break;
        }
    }

    void HandleKeyDown()
    {
        if (Input.GetKeyDown(Key))
            TriggerEvents();
    }

    void HandleKeyUp()
    {
        if (Input.GetKeyUp(Key))
            TriggerEvents();
    }

    void HandleKeyHeld()
    {
        if (Input.GetKey(Key))
            TriggerEvents();
    }

}
