using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTurret", menuName = "Turrets/Turret Object")]
public class TurretObject : ScriptableObject
{
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private AudioClip fireSound;

    public float FireRate => fireRate;
    public GameObject ProjectilePrefab => projectilePrefab;
    public AudioClip FireSound => fireSound;
}
