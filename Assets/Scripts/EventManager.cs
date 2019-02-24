using UnityEngine;
public class EventManager : Singleton<EventManager>
{
    public PlayerDeadStructEvent PlayerDead;
    public PlayerHitStructEvent PlayerHit;
}

public struct PlayerDeadStruct
{
    public Vector3 position;
    public int layer;
}

public struct PlayerHitStruct
{
    public Vector3 position;
    public Vector3 rotation;
    public GameObject gameObject;
}
