using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    const int maxEnergy = 20;
    const int maxGold = 99999999;
    const int maxGem = 99999999;

    public string element = "";
    [HideInInspector] public int baseMaxHp;
    [HideInInspector] public int baseDamage;
    [HideInInspector] public int baseSpeed;

    public int currentHp;
    public int maxHp;
    public int damage;
    public int speed;

    public int energy;
    public int gold;
    public int gem;

    public void InitData()
    {
        currentHp = maxHp = 0;
        damage = 0;
        speed = 4;
    }

    public void InitProperties()
    {
        energy = 20;
        gold = 2000;
        gem = 100;
    }

    public void UpdateStats()
    {
        if (element != "")
        {
            currentHp = maxHp = baseMaxHp;
            damage = baseDamage;
            speed = baseSpeed;
        }
    }

    public void CheckMaxValue()
    {
        if (energy >= maxEnergy)
            energy = maxEnergy;

        if (gold >= maxGold)
            gold = maxGold;

        if (gem >= maxGem)
            gem = maxGem;
    }
}
