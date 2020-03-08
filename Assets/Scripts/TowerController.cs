using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
  public Image ImageTower;

  [NonSerialized]
  public TowerData Data;

  public void Init(TowerData data)
  {
    Data = data;

    ImageTower.sprite = AppController.I.Atlas.GetSprite(data.SpriteName);

    StartCoroutine(ShootCoroutine());
  }

  public void OnSell()
  {
    StopAllCoroutines();
    Destroy(gameObject);
  }

  // TODO: show tower attack range on mouse over

  private IEnumerator ShootCoroutine()
  {
    while (true)
    {
      for (var i = 0; i < AppController.I.Level.Enemies.Count; i++)
      {
        var enemy = AppController.I.Level.Enemies[i];

        if (Vector2.Distance(transform.position, enemy.transform.position) <= Data.Range)
        {
          var projectile = Instantiate(Resources.Load("Prefabs/Projectile"), AppController.I.Level.transform) as GameObject;
          projectile.transform.localPosition = AppController.I.Level.transform.InverseTransformPoint(transform.position);
          projectile.GetComponent<ProjectileController>().Init(enemy, Data.Damage);
          break;
        }
      }

      yield return new WaitForSecondsRealtime(Data.ShootInterval);
    }
  }
}
