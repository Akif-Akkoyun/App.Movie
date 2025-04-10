﻿using App.Movie.Application.Features.MediatorDesignPattern.Results.TagResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.MediatorDesignPattern.Queries.TagQyeries
{
    public class GetTagQuery : IRequest<List<GetTagQueryResult>>
    {
    }
}
