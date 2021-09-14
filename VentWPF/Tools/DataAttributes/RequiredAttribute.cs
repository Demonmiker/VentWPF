using da = System.ComponentModel.DataAnnotations;

namespace VentWPF.Tools
{
    /// <summary>
    /// Атрибут валидации данных с поддержкой русского языка
    /// </summary>
    internal class RequiredAttribute : da.RequiredAttribute
    {
        #region Methods

        public override string FormatErrorMessage(string name) => "Обязательное поле";

        #endregion
    }
}