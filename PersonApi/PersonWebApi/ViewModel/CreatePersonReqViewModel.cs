﻿namespace PersonWebApi.ViewModel
{
    public class CreatePersonReqViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
    }
}
