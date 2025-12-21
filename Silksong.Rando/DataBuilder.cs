
namespace Silksong.Rando;

public abstract class DataBuilder<TResult>
{
    public bool IsBuilt { get; protected set; }
    protected TResult result;


}