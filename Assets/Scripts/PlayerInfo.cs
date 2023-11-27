using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    public string element = "";
    [HideInInspector] public int baseMaxHp;
    [HideInInspector] public int baseDamage;
    [HideInInspector] public int baseSpeed;

    public int currentHp;
    public int maxHp;
    public int speed;
    public int damage;


    public void ResetData()
    {
        if (element != "")
        {
            currentHp = maxHp = baseMaxHp;
            damage = baseDamage;
            speed = baseSpeed;
        }
        else
            speed = 4;
    }
}
