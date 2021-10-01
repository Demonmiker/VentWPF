namespace VentWPF.Fans
{
    /// <summary>
    /// Интерфейс запроса
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IRequest<T>
    {
        T GetRequest();
    }
}