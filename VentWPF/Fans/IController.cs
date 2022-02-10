namespace VentWPF.Fans
{
    /// <summary>
    /// Интерфейс контроллера запросов
    /// </summary>
    /// <typeparam name="Tin">Тип запроса</typeparam>
    /// <typeparam name="Tout">Тип данных ответа</typeparam>
    internal interface IController<Tin, Tout>
    {
        Tout GetResponce(Tin request,out string error);

    }
}