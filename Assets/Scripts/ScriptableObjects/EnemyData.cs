using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemy", order = 2)]
public class EnemyData : ScriptableObject
{
  public string Name;
  public int HealthAmount;
  public int MovingSpeed;
  public int Damage;
  public int RevardMin;
  public int RevardMax;
}
