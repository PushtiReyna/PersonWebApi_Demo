using DTO;
using Helper.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IPerson
    {
        public CommonResponse getall();

        public CommonResponse CreatePerson(CreatePersonReqDTO createPersonReqDTO);

        public CommonResponse UpdatePerson(UpdatePersonReqDTO updatePersonReqDTO);

        public CommonResponse DeletePerson(DeletePersonReqDTO deletePersonReqDTO);
    }
}
