﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Collections;

namespace MVC3NHibernateNinjectNLog.Infastructure.MyMembership
{
    public class EnumerableToEnumerableTConverter<TCollectionType, TItemType> : TypeConverter where TCollectionType : IEnumerable
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType.IsAssignableFrom(typeof(IEnumerable<TItemType>))
                    ? true
                    : base.CanConvertTo(context, destinationType);
        }

        public T ConvertTo<T>(object value)
        {
            return (T)ConvertTo(value, typeof(T));
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            var items = (TCollectionType)value;
            var destination = new List<TItemType>();
            foreach (var item in items)
                destination.Add((TItemType)item);
            return destination;
        }
    }
}