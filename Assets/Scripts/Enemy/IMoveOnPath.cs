public interface IMoveOnPath
{
    float Speed { get; set; }

    void Initialize(IPath path);
}