using UnityEngine;
public class EventManager : Singleton<EventManager>
{
    public PlayerDeadStructEvent PlayerDead;
}

public struct PlayerDeadStruct
{
    public Vector3 position;
    public int layer;
}
