﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDbDTo.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        //
        public int LoginAndPasswordId { get; set; }
    }
}
