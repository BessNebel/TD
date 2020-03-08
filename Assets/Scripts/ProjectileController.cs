using UnityEngine;

public class ProjectileController : MonoBehaviour
{
  private EnemyController Target;
  private int Damage = 0;

  public void Init(EnemyController target, int damage)
  {
    Target = target;
    Damage = damage;
  }

  private void Update()
  {
    if (Target != null)
    {
      var destination = new Vector2(
        Target.transform.localPosition.x + LevelController.CellSize / 2,
        Target.transform.localPosition.y + LevelController.CellSize / 2
      );

      if (Vector2.Distance(transform.localPosition, destination) > 0.1f)
      {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, destination, 400.0f * Time.deltaTime);
      }
      else
      {
        Target.OnDamage(Damage);
        Destroy(gameObject);
      }
    }
    else if (Damage > 0)
    {
      Destroy(gameObject);
    }
  }
}
