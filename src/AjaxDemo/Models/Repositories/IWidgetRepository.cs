using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxDemo.Models
{
    public interface IWidgetRepository
    {
        IQueryable<Widget> Widgets { get; }
        Widget Save(Widget widget);
    }
}
