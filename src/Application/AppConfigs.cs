namespace Application;

public class AppConfigs
{
    /// <summary>
    /// how many items should be downloaded at the same time
    /// </summary>
    public int ParallelismLevel { get; set; }
    /// <summary>
    /// how many items are allowed to be accepted
    /// </summary>
    public int TotalCapacity { get; set; }
}