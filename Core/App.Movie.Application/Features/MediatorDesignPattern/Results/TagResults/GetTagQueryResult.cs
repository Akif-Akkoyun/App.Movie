﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.MediatorDesignPattern.Results.TagResults
{
    public class GetTagQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
