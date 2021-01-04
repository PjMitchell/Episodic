namespace Episodic
{
    public record GetComponentSummaryQuery<TSource>: Query<ComponentSummary[]> where TSource : IComponentSummary 
    {

    }
}
