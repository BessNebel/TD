using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Wave")]
public class WaveData : ScriptableObject
{
  public int Duration;
  public EnemyData Enemy;
}
