using KayraExportCase1.Business.Result;
using KayraExportCase1.Domain.Dtos;
using KayraExportCase1.Domain.ListDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayraExportCase1.Business.Abstract
{
    public interface IProductService
    {
        public Task<SystemResult<ProductListDto>> Save(ProductDto dto);
        public Task<SystemResult<ProductListDto>> Get(int id);
        public Task<SystemResult<ProductListDto>> Delete(int id);
        public Task<PaggingResult<ProductListDto>> GetAll(int page,int count);

    }
}
