using CAFEMENU.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.BackgroundJobs.Hangfire.Recurring
{
    public class ProductJobsManager
    {
        private IProductService _productService;
        public ProductJobsManager(IProductService productService)
        {
            _productService = productService;
        }
        public void Process()
        {
            _productService.UpdateProductPrice();
        }
    }
}
