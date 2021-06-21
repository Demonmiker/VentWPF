using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.Model
{
    public enum coolantType
    {
        Вода,
        Этиленгликоль,
        Пропиленгликоль
    }

    public enum torchType
    {
        Ступенчатая,
        Прогрессивная,
        Модулирующая
    }

    public enum FrType
    {
        R407C,
        R410A
    }

    public enum ClapType
    {
        тип1,
        тип2,
        тип3,
        тип4
    }

    public enum FLType //filter
    {
        тип1,
        тип2,
        тип3        
    }
    public enum Section
    {
        секция500,
        секция1000
    }

    public enum FClassType //class filter
    {
        G4,
        F5,
        F9
    }
}
