﻿namespace CrudWebApi.Models
{
    public class UpdatePersonDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

    }
}
