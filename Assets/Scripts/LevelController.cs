using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LevelController : MonoBehaviour
{
  public static int CellSize = 64;

  public LevelData Data;

  public int Coins;
  public int Health;

  [NonSerialized]
  public List<EnemyController> Enemies = new List<EnemyController>();

  private void Start()
  {
    Coins = Data.Coins;
    Health = Data.Health;

    AppController.Instance.UI.Init();

    StartCoroutine(EnemyAddCoroutine());
  }

  private IEnumerator EnemyAddCoroutine(int waveIndex = 0)
  {
    var duration = Data.Waves[waveIndex].Duration;

    AppController.Instance.UI.SetWave(waveIndex + 1);

    while(duration > 0)
    {
      GameObject enemy = Instantiate(Resources.Load("Prefabs/Enemy"), this.transform) as GameObject;
      var enemyController = enemy.GetComponent<EnemyController>();
      enemyController.Init(Data.Waypoints, Data.Waves[waveIndex].Enemy);

      Enemies.Add(enemyController);

      duration -= 1;

      yield return new WaitForSecondsRealtime(2);
    }

    yield return new WaitForSecondsRealtime(5);

    if (waveIndex + 1 < Data.Waves.Length)
    {
      StartCoroutine(EnemyAddCoroutine(waveIndex + 1));      
    }
    else
    {
      //  TODO: handle win
    }
  }
}
