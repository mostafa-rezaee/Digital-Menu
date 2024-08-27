namespace Common.Query
{
    public class QueryFilter<TResponse, TParam> : IQuery<TResponse> where TResponse : BaseFilter where TParam : BaseFilterParam
    {
        public TParam FilterParam { get; set; }

        public QueryFilter(TParam filterParam)
        {
            FilterParam = filterParam;
        }
    }

}
