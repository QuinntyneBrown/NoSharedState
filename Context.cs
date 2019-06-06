namespace NoSharedState
{
    public interface IContext
    {
        string State { get; set; }
    }

    

    public class Context: IContext
    {

        public string State { get; set; } = "UnSet";
    }
}
