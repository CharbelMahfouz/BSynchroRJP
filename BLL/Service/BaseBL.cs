using AutoMapper;
using BLL.DTOs;
using BLL.Utilities;
using DAL;

namespace BLL.Service
{
    public class BaseBL
    {
        protected readonly IUnitOfWork _uow;
        public BaseBL(IUnitOfWork unit)
        {
            _uow = unit;
        }

        public static ResponseModel CreateResponseModel(int result, string message, dynamic data)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                Result = result,
                Message = message,
                Data = data
            };
            return responseModel;
        }
    }
}
