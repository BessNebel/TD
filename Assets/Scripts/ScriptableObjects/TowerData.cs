using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Tower", order = 1)]
public class TowerData : ScriptableObject
{
  public int BuildPrice;
  public int SellPrice;
  public int Range;
  public int ShootInterval;
  public int Damage;
  public string SpriteName;
}
