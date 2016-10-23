using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CarOwners.Domain.Entities;

namespace CarOwners.Web.Binders
{
    public class OwnerBinder
    {
        //public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        //{
        //    // Получаем поставщик значений
        //    var valueProvider = bindingContext.ValueProvider;

        //    // получаем данные по одному полю
        //    ValueProviderResult vprId = valueProvider.GetValue("Id");

        //    // получаем данные по остальным полям
        //    string name = (string)valueProvider.GetValue("Name").ConvertTo(typeof(string));
        //    string author = (string)valueProvider.GetValue("Author").ConvertTo(typeof(string));
        //    int year = (int)valueProvider.GetValue("Year").ConvertTo(typeof(int));
        //    Owner owner = new Owner() { Name = name + " (new)", Author = author, Year = year };

        //    // если поле Id определено (редактирование)
        //    if (vprId != null)
        //    {
        //        book.Name = name; // без new
        //        book.Id = (int)vprId.ConvertTo(typeof(int));
        //    }
        //    return book;
        //}
    }
}