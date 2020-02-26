using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Wave", order = 3)]
public class WaveData : ScriptableObject
{
  public int Duration;
  public EnemyData Enemy;
}
