using UnityEngine;
using System.Collections;

public class CursorEvent : MonoBehaviour
{
    public Texture2D cursorDefault;
    public Texture2D cursorHover;

    void Start()
    {
        // Debug.Log("CursorEvent script attached to: " + gameObject.name);
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }

    public void OnButtonCursorEnter()
    {
        Debug.Log("Cursor hover texture: " + cursorHover.name);
        Cursor.SetCursor(cursorHover, Vector2.zero, CursorMode.Auto);
    }

    public void OnButtonCursorExit()
    {
        Debug.Log("Cursor default texture: " + cursorDefault.name);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
