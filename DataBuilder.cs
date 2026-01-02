
namespace Silksong.Rando;

public abstract class DataBuilder<TResult> where TResult : class
{
    protected bool IsBuilt { get; set; }
    public TResult result = null!;
}