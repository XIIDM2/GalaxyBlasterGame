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

        SerializedProperty entityPrefab = serializedObject.FindProperty("entityPrefab");
        SerializedProperty spawnPoints = serializedObject.FindProperty("spawnPoints");
        SerializedProperty spawnType = serializedObject.FindProperty("spawnType");
        SerializedProperty spawnPointNumber = serializedObject.FindProperty("spawnPointNumber");
        SerializedProperty spawnTime = serializedObject.FindProperty("spawnTime");
        SerializedProperty spawnAmount = serializedObject.FindProperty("spawnAmount");
        SerializedProperty loopSpawn = serializedObject.FindProperty("loopSpawn");

        EditorGUILayout.PropertyField(entityPrefab);

        EditorGUILayout.PropertyField(spawnPoints);
        EditorGUILayout.PropertyField(spawnType);

        EditorGUILayout.PropertyField(spawnAmount);

        EditorGUILayout.PropertyField(loopSpawn);

        if (spawnType.enumValueIndex == 0)
        {
            EditorGUILayout.PropertyField(spawnPointNumber);
        }

        if (loopSpawn.boolValue)
        {
            EditorGUILayout.PropertyField(spawnTime);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
