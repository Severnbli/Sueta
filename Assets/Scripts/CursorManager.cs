using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    private Vector2 _cursorHotspot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
    }
    
    public void SelectCursor()
    {
        Cursor.SetCursor(cursorTexture, _cursorHotspot, CursorMode.Auto);
    }

    public void DefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
