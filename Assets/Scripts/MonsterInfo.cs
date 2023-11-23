using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/MonsterInfo")]
public class MonsterInfo : ScriptableObject
{
    public MonsterType type;
    public int hp;
    public int speed;
    public int powerDamage;
}
