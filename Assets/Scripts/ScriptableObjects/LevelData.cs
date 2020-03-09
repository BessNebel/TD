using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Level")]
public class LevelData : ScriptableObject
{
  public int Coins = 100;
  public int Health = 100;
  public TowerData[] Towers;
  public WaveData[] Waves;
  public Vector2[] Waypoints;
}
