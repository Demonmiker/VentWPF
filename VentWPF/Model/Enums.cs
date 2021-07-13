using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentWPF.Model
{
    public enum CoolantType { Вода, Этиленгликоль, Пропиленгликоль }

    public enum TorchType { Ступенчатая, Прогрессивная, Модулирующая }

    public enum FrType { R407C, R410A }

    public enum ValveType { тип1, тип2, тип3, тип4 }

    public enum FilterType { тип1, тип2, тип3 }

    public enum Section { секция500, секция1000 }

    public enum FilterClassType { G4, F5, F9 }

    public enum Rows { Одиноярусный, Двуярусный}

    public enum Realization { ТРЕНД, Климат, Эксперт  }

    public enum Maintenance { Справа, Слева, }

    public enum ValvePos { Снаружи, Внутри }

}
