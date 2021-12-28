namespace ApproxWeatherAPI.Entities
{
  public record APIResult
  {
    public int Id { get; set; }

    public string Datetime { get; set; }

    public float Temperature { get; set; }

    public int ExecutionId { get; set; }

    public Execution Execution { get; set; }
  }
}