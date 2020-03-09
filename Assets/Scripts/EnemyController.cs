using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
  public Image ImageHealth;

  private Queue<Vector2> Waypoints = new Queue<Vector2>();
  private EnemyData Data;
  private EnemyAnimationController AnimationController;
  private int HealthAmount;

  // NOTE: pass waypoints to each instance for different path support
  public void Init(Vector2[] levelWaypoints, EnemyData data)
  {
    transform.localPosition = new Vector2(levelWaypoints[0].x * LevelController.CellSize, levelWaypoints[0].y * LevelController.CellSize);

    for (var i = 1; i < levelWaypoints.Length; i++)
    {      
      Waypoints.Enqueue(new Vector2(levelWaypoints[i].x * LevelController.CellSize, levelWaypoints[i].y * LevelController.CellSize));
    }

    Data = data;
    HealthAmount = Data.HealthAmount;

    GameObject Enemy = Instantiate(Resources.Load("Prefabs/Enemy" + Data.Name), this.transform) as GameObject;
    AnimationController = Enemy.GetComponent<EnemyAnimationController>();

    Move();    
  }

  public void OnDamage(int damage)
  {
    HealthAmount -= damage;
    ImageHealth.fillAmount = (float)HealthAmount / (float)Data.HealthAmount;

    if (HealthAmount <= 0)
    {
      OnDeath(true);
    }
  }

  public void OnDeath(bool killedByTower = false)
  {
    if (killedByTower)
    {    
      AppController.Instance.UI.Gain(Random.Range(Data.RevardMin, Data.RevardMax));
    }

    AppController.Instance.Level.Enemies.Remove(this);
    StopAllCoroutines();
    Destroy(gameObject);
  }

  private void Move()
  {
    if (Waypoints.Count > 0)
    {      
      StartCoroutine(TestCoroutine(Waypoints.Dequeue()));
    }
    else
    {
      AppController.Instance.UI.Damage(Data.Damage);
      OnDeath();
    }
  }

  private IEnumerator TestCoroutine(Vector2 waypoint)
  {
    var direction = (waypoint - new Vector2(transform.localPosition.x, transform.localPosition.y));
    direction.Normalize();

    switch (Mathf.Round(Vector2.SignedAngle(Vector2.right, direction)))
    {
      case 0:
        AnimationController.Right();
        break;
      case -90:
        AnimationController.Down();
        break;
      case 90:
        AnimationController.Top();
        break;
      case 180:
        AnimationController.Left();
        break;
    }
    
    while(Vector2.Distance(transform.localPosition, waypoint) > 1f)
    {
      transform.localPosition = Vector2.MoveTowards(transform.localPosition, waypoint, Data.MovingSpeed);
      
      yield return new WaitForSecondsRealtime(.02f);
    }
    
    Move();
  }
}
