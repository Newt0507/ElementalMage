using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/ElementInfo")]
public class ElementInfo : ScriptableObject
{
    public string elementName;
    public int baseMaxHp;
    public int baseDamage;
    public int baseSpeed;
}