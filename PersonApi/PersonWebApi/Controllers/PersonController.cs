using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonWebApi.ViewModel;
using ServiceLayer.Interface;
using Mapster;
using DataLayer.Entities;
using Helper.CommonModels;
using Azure;

namespace PersonWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public readonly IPerson _person;
        public PersonController(IPerson person)
        {
            _person = person;

        }
        [HttpGet]
        public CommonResponse GetAll()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _person.getall();
                List<GetPersonResDTO> lstGetPersonResDTO = response.Data;  
                response.Data = lstGetPersonResDTO.Adapt<List<GetPersonResViewModel>>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost]
        public CommonResponse CreatePerson(CreatePersonReqViewModel createPersonReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _person.CreatePerson(createPersonReqViewModel.Adapt<CreatePersonReqDTO>());
                CreatePersonResDTO createPersonResDTO = response.Data;
                response.Data = createPersonResDTO.Adapt<CreatePersonResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut]
        public CommonResponse UpdatePerson(UpdatePersonReqViewModel updatePersonReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _person.UpdatePerson(updatePersonReqViewModel.Adapt<UpdatePersonReqDTO>());
                UpdatePersonResDTO updatePersonResDTO = response.Data;
                response.Data = updatePersonResDTO.Adapt<UpdatePersonResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpDelete]
        public CommonResponse DeletePerson(DeletePersonReqViewModel deletePersonReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = _person.DeletePerson(deletePersonReqViewModel.Adapt<DeletePersonReqDTO>());
                DeletePersonResDTO deletePersonResDTO = response.Data;
                response.Data = deletePersonResDTO.Adapt<DeletePersonResViewModel>();
            }
            catch { throw; }
            return response;
        }
    }
}
