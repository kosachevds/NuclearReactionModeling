namespace NuclearReactionModeling
{
    interface IShape
    {
        bool IsInternalPoint(double x, double y, double z);

        bool IsInternalPoint(Point point);
    }
}