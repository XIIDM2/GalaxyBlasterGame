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
            Debug.LogFormat("Здоровье изменилось на {0}", health);
        } 
    }
}
