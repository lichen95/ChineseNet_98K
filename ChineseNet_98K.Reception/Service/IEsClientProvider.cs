using Nest;

namespace ChineseNet_98K.Reception.Service
{
    public interface IEsClientProvider
    {
        ElasticClient GetClient();
    }
}