﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    class AccountTypeDTO
    {
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public AccountTypeDTO(DataRow dataRow)
        {
            Id = (int)dataRow["id"];
            Name = dataRow["name"].ToString();
        }
    }
}
