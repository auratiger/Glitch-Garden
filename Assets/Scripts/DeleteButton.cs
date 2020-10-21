using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    [SerializeField] private Texture2D _texture2D;
    
    private void OnMouseDown()
    {
        Cursor.SetCursor(_texture2D, Vector2.zero, CursorMode.Auto);
        FindObjectOfType<LevelController>().SetDeleteCursor(true);
        FindObjectOfType<DefenderButton>().DeselectButtons();
    }
    
}
