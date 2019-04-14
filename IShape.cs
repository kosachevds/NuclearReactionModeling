namespace NuclearReactionModeling
{
    interface IShape
    {
        bool IsInternalPoint(Vector3 point);

        Vector3 RandomPointFromSurface();
    }
}