namespace GFood_CaseStudy.Core.CrossCuttingConcerns
{
    public interface ICacheService
    {
        T Get<T>(string key);
        object Get(string key);
        void Set(string key, object value, int duration);
        bool IsExists(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
