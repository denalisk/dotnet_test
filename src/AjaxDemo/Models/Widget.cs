using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxDemo.Models
{
    [Table("Widgets")]
    public class Widget
    {
        public override bool Equals(System.Object otherWidget)
        {
            if (!(otherWidget is Widget))
            {
                return false;
            }
            else
            {
                Widget newWidget = (Widget)otherWidget;
                return this.Id.Equals(newWidget.Id);
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
