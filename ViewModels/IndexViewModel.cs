using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IPSAlyzer_v1.Models;
using PagedList;

namespace IPSAlyzer_v1.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<recipe> P_rcp
        {
            get;
            set;
        }

        public IEnumerable<Product_Cat> P_Cat
        {
            get;
            set;
        }

        public IEnumerable<Product_Func> P_Func
            {
                get;
                set;    
            }
           public IPagedList<Product> P_s
        {
            get;
            set;
        }
        public IEnumerable<Product> P_recipe
        {
            get;
            set;
        }
    }
}