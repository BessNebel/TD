using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.U2D;

public class AppController : MonoBehaviour
{
  public static AppController I = null;

  public UIController UI;

  public SpriteAtlas Atlas;
  public LevelController Level;
  public TowerData[] Towers;
  public WaveData[] Waves;

  private void Start()
  {
    if (I == null)
    {
      I = this;
    }
    else if (I == this)
    {
      Destroy(gameObject);
    }
  }
}
