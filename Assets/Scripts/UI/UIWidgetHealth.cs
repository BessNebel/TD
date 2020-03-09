public class UIWidgetHealth : UIWidgetCounter
{
  public override int Value
  {
    get { return AppController.Instance.Health; }
    set { AppController.Instance.Health = value; }
  }

  private void Start()
  {
    Format = "Health: {0}";
  }
}
