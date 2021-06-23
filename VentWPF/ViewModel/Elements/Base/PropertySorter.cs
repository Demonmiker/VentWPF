using System;
using System.Collections;
using System.ComponentModel;

namespace VentWPF.ViewModel
{
    /// <summary>/// Атрибут для задания сортировки/// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyOrderAttribute : Attribute
    {
        private int _order;

        public PropertyOrderAttribute(int order)
        {
            _order = order;
        }

        public int Order
        {
            get { return _order; }
        }
    }

    public class PropertyOrderPair : IComparable
    {
        private string _name;
        private int _order;

        public PropertyOrderPair(string name, int order)
        {
            _order = order;
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public int CompareTo(object obj)
        {
            int otherOrder = ((PropertyOrderPair)obj)._order;

            if (otherOrder == _order)
            {
                // если Order одинаковый - сортируем по именам
                string otherName = ((PropertyOrderPair)obj)._name;
                return string.Compare(_name, otherName);
            }
            else if (otherOrder > _order)
                return -1;

            return 1;
        }
    }

    public class PropertySorter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(
        ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection pdc =
              TypeDescriptor.GetProperties(value, attributes);

            ArrayList orderedProperties = new ArrayList();

            foreach (PropertyDescriptor pd in pdc)
            {
                Attribute attribute = pd.Attributes[typeof(PropertyOrderAttribute)];

                if (attribute != null)
                {
                    // атрибут есть - используем номер п/п из него
                    PropertyOrderAttribute poa = (PropertyOrderAttribute)attribute;
                    orderedProperties.Add(new PropertyOrderPair(pd.Name, poa.Order));
                }
                else
                {
                    // атрибута нет – считаем, что 0
                    orderedProperties.Add(new PropertyOrderPair(pd.Name, 0));
                }
            }

            // сортируем по Order-у
            orderedProperties.Sort();

            // формируем список имен свойств
            ArrayList propertyNames = new ArrayList();

            foreach (PropertyOrderPair pop in orderedProperties)
                propertyNames.Add(pop.Name);

            // возвращаем
            return pdc.Sort((string[])propertyNames.ToArray(typeof(string)));
        }
    }
}