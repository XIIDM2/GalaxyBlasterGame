using UnityEngine;

public class Player : MonoBehaviour
{
    private int health;

    public int Health
    { 
        get 
        { 
            return health; 
        } 
        set 
        { 
            health = value;
            Debug.LogFormat("�������� ���������� �� {0}", health);
        } 
    }
}
