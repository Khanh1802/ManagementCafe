﻿namespace ManagerCafe.Dtos.UserTypeDtos
{
    public class UpdateUserTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
