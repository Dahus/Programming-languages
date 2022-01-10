using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelEditor : EditorWindow
{
    private Transform _parent;
    private EditorData _data;
    private int _index;
    private bool isEnebledEditor;
    private bool isDeleteEditor;
    private GameLevel _gameLevel;
    public string _nameLevelXml;
    private SceneEditor _sceneEditor;
    [MenuItem("Window/Level Editor")]
    public static void Init() 
    {
        LevelEditor levelEditor = GetWindow<LevelEditor>("Level Editor");
        levelEditor.Show();
    }

    public string GetNameFile() 
    {
        return _nameLevelXml;
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(10);
        _parent = (Transform)EditorGUILayout.ObjectField(_parent, typeof(Transform), true);
        EditorGUILayout.Space(30);

        if (_data == null)
        { 
            if(GUILayout.Button("Load data")) 
            {
                _data = (EditorData)AssetDatabase.LoadAssetAtPath("Assets/Data/EditorData.asset", typeof(EditorData));
                _sceneEditor = CreateInstance<SceneEditor>();
                _sceneEditor.SetLevelEditor(this, _parent);
            }
        }
        else 
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("Block Prefab", EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("<", GUILayout.Width(50), GUILayout.Height(50)))
            {
                _index--;
                if (_index < 0) 
                {
                    _index = _data.blockDatas.Count - 1;
                }
            }

            //GUI.color = _data.blockDatas[_index].blockData.baseColor;

            GUILayout.Label(_data.blockDatas[_index].texture);
        
            if (GUILayout.Button(">", GUILayout.Width(50), GUILayout.Height(50))) 
            {
                _index++;
                if (_index > _data.blockDatas.Count - 1)
                {
                    _index = 0;
                }
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.Space(30);

            GUI.color = isEnebledEditor ? Color.red : Color.white;
            if (GUILayout.Button("Create blocks"))
            {
                isEnebledEditor = !isEnebledEditor;
                if (isEnebledEditor) 
                {
                    SceneView.duringSceneGui += _sceneEditor.OnSceneGUI;
                }
                else 
                {
                    SceneView.duringSceneGui -= _sceneEditor.OnSceneGUI;
                }
            }
           


            GUI.color = Color.white;
            GUILayout.Space(30);

            _gameLevel = EditorGUILayout.ObjectField(_gameLevel, typeof(GameLevel), false) as GameLevel;
            GUILayout.Space(10);

            _nameLevelXml = EditorGUILayout.TextField(_nameLevelXml);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Save Level ")) 
            {
                SaveLevel saveLevel = new SaveLevel();
                _gameLevel._listBlocks = saveLevel.GetBlocks(_nameLevelXml);
                _gameLevel.InitLevel();
                Debug.Log("Level Saved");
            }
            if (GUILayout.Button("Load Level")) 
            {
                GameObject[] allBlocks = GameObject.FindGameObjectsWithTag("Block");
                foreach(var item in allBlocks) 
                {
                    DestroyImmediate(item.gameObject);
                }
                SaveLevel saveLevel = new SaveLevel();
                //saveLevel.LoadBlock(_nameLevelXml);
                BlockGenerator generator = new BlockGenerator();
                generator.GenerateXElement(saveLevel.LoadBlock(_nameLevelXml),_parent,_gameLevel);
               
               
                generator.Generate(_gameLevel, _parent);
            }
            GUILayout.EndHorizontal();
        }
    }

    public BlockData GetBlock() 
    {
        return _data.blockDatas[_index].blockData;
    }
}
