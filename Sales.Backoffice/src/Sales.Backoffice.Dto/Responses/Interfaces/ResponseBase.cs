using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Backoffice.Dto.Responses.Interfaces;

public class ResponseBase : IResponse<ResponseBase>
{
    public ResponseBase Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
