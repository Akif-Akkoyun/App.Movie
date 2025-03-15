using App.Movie.Application.Features.MediatorDesignPattern.Results.CastResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Movie.Application.Features.MediatorDesignPattern.Queries.CastQueries
{
    public class GetCastByIdQuery : IRequest<GetCastByIdQueryResult>
    {
        public GetCastByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
