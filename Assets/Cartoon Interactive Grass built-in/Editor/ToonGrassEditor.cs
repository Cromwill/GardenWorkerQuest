using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(ToonGrassPainter))]
[InitializeOnLoad]
public class ToonGrassEditor : Editor
{
    ToonGrassPainter toonGrass;
    readonly string[] editorStrs = { "Add Grass", "Remove Grass", "Edit Current Grass" };

    readonly string[] editorCurrStrs = { "Change Colors", "Change Length/Width", "Change All" };

    private void OnEnable()
    {
        toonGrass = (ToonGrassPainter)target;
    }


    static string GetPath(string _scriptName)
    {
        string[] path = UnityEditor.AssetDatabase.FindAssets(_scriptName);
        if (path.Length > 1)
        {
            return null;
        }
        string _path = AssetDatabase.GUIDToAssetPath(path[0]).Replace((@"/" + _scriptName + ".cs"), "");
        return _path;
    }


    void OnSceneGUI()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(toonGrass.hitPosGizmo, toonGrass.hitNormal, toonGrass.brushSize);
        Handles.color = new Color(0, 0.5f, 0.5f, 0.4f);
        Handles.DrawSolidDisc(toonGrass.hitPosGizmo, toonGrass.hitNormal, toonGrass.brushSize);

        if (toonGrass.toolbarInt == 1)
        {
            Handles.color = Color.red;
            Handles.DrawWireDisc(toonGrass.hitPosGizmo, toonGrass.hitNormal, toonGrass.brushSize);
            Handles.color = new Color(0.5f, 0f, 0f, 0.4f);
            Handles.DrawSolidDisc(toonGrass.hitPosGizmo, toonGrass.hitNormal, toonGrass.brushSize);
        }
        if (toonGrass.toolbarInt == 2)
        {
            Handles.color = Color.yellow;
            Handles.DrawWireDisc(toonGrass.hitPosGizmo, toonGrass.hitNormal, toonGrass.brushSize);
            Handles.color = new Color(0.5f, 0.5f, 0f, 0.4f);
            Handles.DrawSolidDisc(toonGrass.hitPosGizmo, toonGrass.hitNormal, toonGrass.brushSize);

            Handles.color = Color.yellow;
            Handles.DrawWireDisc(toonGrass.hitPosGizmo, toonGrass.hitNormal, toonGrass.brushFalloffSize);
            Handles.color = new Color(0.5f, 0.5f, 0f, 0.4f);
            Handles.DrawSolidDisc(toonGrass.hitPosGizmo, toonGrass.hitNormal, Mathf.Clamp(toonGrass.brushFalloffSize, 0, toonGrass.brushSize));
        }
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Grass Max Limit", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(toonGrass.i.ToString() + "/", EditorStyles.label);
        toonGrass.grassLimit = EditorGUILayout.IntField(toonGrass.grassLimit);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Hit Set", EditorStyles.boldLabel);
        LayerMask tempMask = EditorGUILayout.MaskField("Hit Mask", InternalEditorUtility.LayerMaskToConcatenatedLayersMask(toonGrass.hitMask), InternalEditorUtility.layers);
        toonGrass.hitMask = InternalEditorUtility.ConcatenatedLayersMaskToLayerMask(tempMask);
        LayerMask tempMask2 = EditorGUILayout.MaskField("Painting Mask", InternalEditorUtility.LayerMaskToConcatenatedLayersMask(toonGrass.paintMask), InternalEditorUtility.layers);
        toonGrass.paintMask = InternalEditorUtility.ConcatenatedLayersMaskToLayerMask(tempMask2);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Paint Status (Right-Mouse Button to paint)", EditorStyles.boldLabel);
        toonGrass.toolbarInt = GUILayout.Toolbar(toonGrass.toolbarInt, editorStrs);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Brush Settings", EditorStyles.boldLabel);

        toonGrass.brushSize = EditorGUILayout.Slider("Brush Size", toonGrass.brushSize, 0.1f, 10f);

        if (toonGrass.toolbarInt == 0)
        {
            toonGrass.normalLimit = EditorGUILayout.Slider("Normal Limit", toonGrass.normalLimit, 0f, 1f);
            toonGrass.density = EditorGUILayout.Slider("Density", toonGrass.density, 0.1f, 10f);

        }
        if (toonGrass.toolbarInt == 2)
        {
            toonGrass.toolbarIntEdit = GUILayout.Toolbar(toonGrass.toolbarIntEdit, editorCurrStrs);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Soft Falloff Settings", EditorStyles.boldLabel);
            toonGrass.brushFalloffSize = EditorGUILayout.Slider("Brush Falloff Size", toonGrass.brushFalloffSize, 0.1f, 10f);
            toonGrass.Flow = EditorGUILayout.Slider("Brush Flow", toonGrass.Flow, 1, 20f);

        }


        if (toonGrass.toolbarInt == 0 || toonGrass.toolbarInt == 2)
        {


            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Width and Length ", EditorStyles.boldLabel);
            toonGrass.sizeWidth = EditorGUILayout.Slider("Width", toonGrass.sizeWidth, 0f, 2f);
            toonGrass.sizeLength = EditorGUILayout.Slider("Length", toonGrass.sizeLength, 0f, 2f);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Color", EditorStyles.boldLabel);
            toonGrass.AdjustedColor = EditorGUILayout.ColorField("Base Color", toonGrass.AdjustedColor);
            EditorGUILayout.LabelField("Random Color Weights", EditorStyles.boldLabel);
            toonGrass.rangeR = EditorGUILayout.Slider("Red Weights", toonGrass.rangeR, 0f, 1f);
            toonGrass.rangeG = EditorGUILayout.Slider("Green Weights", toonGrass.rangeG, 0f, 1f);
            toonGrass.rangeB = EditorGUILayout.Slider("Blue Weights", toonGrass.rangeB, 0f, 1f);
        }

        if (GUILayout.Button("Clear Mesh"))
        {
            if (EditorUtility.DisplayDialog("Clear Mesh?",
               "Are you sure clear the mesh?", "Clear", "Don't Clear"))
            {
                toonGrass.ClearMesh();
            }
        }
    }

    [MenuItem("Tools/Cartoon Interactive Grass built-in/Create")]
    private static void Create()
    {
        var localPath = GetPath("ToonGrassEditor");
        if (string.IsNullOrEmpty(localPath))
        {
            Debug.LogError("The path is wrong, please do not change the internal directory structure of the plug-in.");
            return;
        }
        localPath = localPath.Replace(@"\", "/");
        var tempPath = localPath.Replace("/Editor", "/Prefab/ToonGrassTemp.prefab");
        var tempObj = AssetDatabase.LoadAssetAtPath(tempPath, typeof(GameObject)) as GameObject;
        if (tempObj != null)
        {
            var obj = GameObject.Instantiate(tempObj);
            obj.name = "OneToonGrass";
            Selection.activeObject = obj;
        }
    }


}
