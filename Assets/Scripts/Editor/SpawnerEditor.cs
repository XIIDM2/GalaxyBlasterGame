using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SerializedProperty enemyPrefab = serializedObject.FindProperty("enemyPrefab");
        SerializedProperty spawnPoints = serializedObject.FindProperty("spawnPoints");
        SerializedProperty spawnType = serializedObject.FindProperty("spawnType");
        SerializedProperty spawnPointNumber = serializedObject.FindProperty("spawnPointNumber");
        SerializedProperty spawnTime = serializedObject.FindProperty("spawnTime");
        SerializedProperty spawnAmount = serializedObject.FindProperty("spawnAmount");

        EditorGUILayout.PropertyField(spawnPoints);
        EditorGUILayout.PropertyField(enemyPrefab);
        EditorGUILayout.PropertyField(spawnType);
        EditorGUILayout.PropertyField(spawnTime);
        EditorGUILayout.PropertyField(spawnAmount);

        if (spawnType.enumValueIndex == 0)
        {
            EditorGUILayout.PropertyField(spawnPointNumber);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
