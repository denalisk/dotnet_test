using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxDemo.Models.Repositories
{
    public class EFWidgetRepository : IWidgetRepository
    {
        public static DbContextOptions<AjaxDemoDbContext> ContextOptions = new DbContextOptions<AjaxDemoDbContext>();
        AjaxDemoDbContext db = new AjaxDemoDbContext(ContextOptions);

       public IQueryable<Widget> Widgets
        {
            get { return db.Widgets; }
        }

        public Widget Save(Widget widget)
        {
            db.Widgets.Add(widget);
            db.SaveChanges();
            return widget;
        }

        public EFWidgetRepository(AjaxDemoDbContext connection = null)
        {
            if (connection == null)
            {
                this.db = new AjaxDemoDbContext(ContextOptions);
            }
            else
            {
                this.db = connection;
            }
        }
    }
}
