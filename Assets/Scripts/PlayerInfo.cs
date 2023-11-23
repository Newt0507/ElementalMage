using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    public int currentHp;
    public int maxHp;
    public int speed;
    public int powerDamage;

    private int defaultMaxHp = 100;
    private int defaultPowerDamage = 10;

    public void ResetData()
    {
        currentHp = maxHp = defaultMaxHp;
        powerDamage = defaultPowerDamage;
    }
}
