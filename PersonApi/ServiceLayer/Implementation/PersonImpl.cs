using BusinessLayer;
using DataLayer.Entities;
using DTO;
using Helper.CommonModels;
using Mapster;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class PersonImpl : IPerson
    {
        public readonly PersonBLL _personBLL;
        public PersonImpl(PersonBLL personBLL)
        {
            _personBLL = personBLL;

        }
        public CommonResponse getall()
        {
           return  _personBLL.getall(); 
        }

        public CommonResponse CreatePerson(CreatePersonReqDTO createPersonReqDTO)
        {
            return _personBLL.CreatePerson(createPersonReqDTO);
        }

        public CommonResponse UpdatePerson(UpdatePersonReqDTO updatePersonReqDTO)
        {
            return _personBLL.UpdatePerson(updatePersonReqDTO);
        }
        public CommonResponse DeletePerson(DeletePersonReqDTO deletePersonReqDTO)
        {
            return _personBLL.DeletePerson(deletePersonReqDTO);
        }
    }
}
