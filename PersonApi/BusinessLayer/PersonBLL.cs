using Azure;
using DataLayer.Entities;
using DTO;
using Helper.CommonModels;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PersonBLL
    {
        public readonly PersonApidbContext _db;
        public PersonBLL(PersonApidbContext db)
        {
          _db = db;
        }

        public CommonResponse getall()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                GetPersonResDTO getPersonResDTO = new GetPersonResDTO();

                List<GetPersonResDTO> lstGetPersonResDTO = new List<GetPersonResDTO>();
                foreach (PersonMst person in _db.PersonMsts.ToList())
                {
                    getPersonResDTO = new GetPersonResDTO();
                    getPersonResDTO.Id = person.Id;
                    getPersonResDTO.FirstName = person.FirstName;
                    getPersonResDTO.LastName = person.LastName;
                    lstGetPersonResDTO.Add(getPersonResDTO);
                }
               
                if (lstGetPersonResDTO.Count > 0)
                {
                    response.Data = lstGetPersonResDTO;
                    response.Status = true;
                    response.Message = "List of person found.";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "List of person not found.";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response; 
        }

        public CommonResponse CreatePerson(CreatePersonReqDTO createPersonReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                CreatePersonResDTO createPersonResDTO = new CreatePersonResDTO();

                PersonMst personMst = new PersonMst();
                personMst.FirstName = createPersonReqDTO.FirstName;
                personMst.LastName = createPersonReqDTO.LastName;

                _db.PersonMsts.Add(personMst);
                _db.SaveChanges();

                createPersonResDTO.Id = personMst.Id;

                if (createPersonResDTO != null)
                {
                    response.Data = createPersonResDTO;
                    response.Status = true;
                    response.Message = "Add Successfully.";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Person Not Add succsefully";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch 
            {
                throw;
            }
            return response;
        }

        public CommonResponse UpdatePerson(UpdatePersonReqDTO updatePersonReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdatePersonResDTO updatePersonResDTO = new UpdatePersonResDTO();

                PersonMst personMst = new PersonMst();
                personMst = _db.PersonMsts.FirstOrDefault(x => x.Id == updatePersonReqDTO.Id);

                if (personMst != null)
                {
                    //personMst.Id = id;
                    personMst.FirstName = updatePersonReqDTO.FirstName;
                    personMst.LastName = updatePersonReqDTO.LastName;
                    _db.Entry(personMst).State = EntityState.Modified;
                    _db.SaveChanges();

                    updatePersonResDTO.Id = personMst.Id;
                    

                    if (updatePersonResDTO != null)
                    {
                        response.Data = updatePersonResDTO;
                        response.Status = true;
                        response.Message = "update Successfully";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                else
                {
                    response.Message = "Person Not Found";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            
            }
            catch { throw; }
            return response;
        }

        public CommonResponse DeletePerson(DeletePersonReqDTO deletePersonReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                DeletePersonResDTO deletePersonResDTO = new DeletePersonResDTO();

                PersonMst personMst = new PersonMst();
                personMst = _db.PersonMsts.FirstOrDefault(x => x.Id == deletePersonReqDTO.Id);

                if (personMst != null)
                {
                    //personMst.Id = id;
                    _db.PersonMsts.Remove(personMst);
                    _db.SaveChanges();
                    deletePersonResDTO.Id = personMst.Id;
                    
                    if (deletePersonResDTO != null)
                    {
                        response.Data = deletePersonResDTO;
                        response.Status = true;
                        response.Message = "delete Successfully";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                else
                {
                    response.Message = "Person Not Found";
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;
                }
            }
            catch { throw; }
            return response;
        }


        //public CommonResponse FunctionName() //Model
        //{
        //    CommonResponse response = new CommonResponse();
        //    try
        //    {

        //    }
        //    catch { throw;}
        //    return response;
        //}
    }
}
