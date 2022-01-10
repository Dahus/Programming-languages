using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class SceneEditor : EditorWindow
{
    private readonly EditorGrid _grid = new EditorGrid();
    private LevelEditor _levelEditor;
    private Transform _parent;
    public void SetLevelEditor(LevelEditor levelEditor,Transform parent) 
    {
        _parent = parent;
        _levelEditor = levelEditor;
    }

    public void OnSceneGUI(SceneView sceneView) 
    {
        Event current = Event.current;
        if (current.type == EventType.MouseDown) 
        {
           
            Vector3 point = sceneView.camera.ScreenToWorldPoint(new Vector3(current.mousePosition.x,
                sceneView.camera.pixelHeight - current.mousePosition.y, sceneView.camera.nearClipPlane));
            Debug.Log(point);
           Vector3 _position = _grid.CheckPosition(point);
            if (_position != Vector3.zero)
            {
                if (isEmpty(_position))
                {
                    GameObject game = PrefabUtility.InstantiatePrefab(_levelEditor.GetBlock().prefab, _parent) as GameObject;
                    game.transform.position = _position;
                }
            }
        }
        if (current.type == EventType.Layout) 
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
        }

        
        if (current.type == EventType.MouseDown) 
        {
            Vector3 point = sceneView.camera.ScreenToWorldPoint(new Vector3(current.mousePosition.x,
               sceneView.camera.pixelHeight - current.mousePosition.y, sceneView.camera.nearClipPlane));
            
        }

    }
    private bool isEmpty(Vector3 position) 
    {
        Collider2D collider = Physics2D.OverlapCircle(position, 0.2f);
        return collider==null;
    }

}
