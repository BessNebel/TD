public class UIWidgetCoins : UIWidgetCounter
{
  public override int Value
  {
    get { return AppController.Instance.Coins; }
    set { AppController.Instance.Coins = value; }
  }

  private void Start()
  {
    Format = "Coins: {0}";
  }
}
