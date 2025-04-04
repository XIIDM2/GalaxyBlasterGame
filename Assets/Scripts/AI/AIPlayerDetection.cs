using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject.SpaceFighter;

public class AIPlayerDetection : MonoBehaviour
{
    [SerializeField] private CircleCollider2D playerDetecionArea;
    [SerializeField] private float radius = 20.0f;

    [SerializeField] private bool isInFight = false;

    private Transform player;
    public Transform Player => player;

    public bool IsInFight => isInFight;

    private void Start()
    {
        if (playerDetecionArea != null)
        {
            playerDetecionArea.radius = radius;
            playerDetecionArea.isTrigger = true;
        }
        else
        {
            Debug.LogFormat("{0} does not contain component CircleCollider2D", gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.root.TryGetComponent<PlayerInputController>(out _)) return;

        SetTarget(collision.transform.root);

        isInFight = true;

        Debug.LogFormat("{0} entered Fight radius for {1}", collision.transform.root.name, gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.transform.root.TryGetComponent<PlayerInputController>(out _)) return;

        SetTarget(null);

        isInFight = false;

        Debug.LogFormat("{0} exit Fight radius for {1}", collision.transform.root.name, gameObject.name);
    }

    private void SetTarget(Transform target)
    {
        player = target;
    }
}
