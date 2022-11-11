public class CollisionCount : UIElements
{
    private void Start()
    {
        collusionText.text = "Столкновений: " + collusionCount.ToString();
    }
}