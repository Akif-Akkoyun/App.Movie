﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.CQRSDesignPattern.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
