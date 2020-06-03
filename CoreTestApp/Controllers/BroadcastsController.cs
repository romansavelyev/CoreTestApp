using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTestApp.Persistance.Models;
using CoreTestApp.Queries.Broadcast.Get;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace CoreTestApp.API.Controllers
{
    public class BroadcastsController : ODataController
    {
        private readonly IMediator _mediator;
        public BroadcastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [EnableQuery]
        public ActionResult<IEnumerable<Broadcast>> Get()
        {
            var defaultBroadcastTypeId = new Guid("0151059b-a859-4931-f3f2-08d773208df1");
            return new List<Broadcast>()
            {
                new Broadcast
                {
                    BroadcastId = Guid.NewGuid(),
                    Title = "NBA Finals",
                    BroadcastTypeId = defaultBroadcastTypeId
                },
                new Broadcast
                {
                    BroadcastId = Guid.NewGuid(),
                    Title = "WCF Finals",
                    BroadcastTypeId = defaultBroadcastTypeId
                },
            };
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<object>> Get(ODataQueryOptions<Broadcast> options)
        //{
        //    var defaultBroadcastTypeId = new Guid("0151059b-a859-4931-f3f2-08d773208df1");
        //    var list = new List<Broadcast>(){
        //        new Broadcast
        //        {
        //            BroadcastId = Guid.NewGuid(),
        //            Title = "NBA Finals",
        //            BroadcastTypeId = defaultBroadcastTypeId
        //        },
        //        new Broadcast
        //        {
        //            BroadcastId = Guid.NewGuid(),
        //            Title = "WCF Finals",
        //            BroadcastTypeId = defaultBroadcastTypeId
        //        },
        //    }.AsQueryable();
        //    return options.ApplyTo(list).Cast<object>().ToList();
        //    //try
        //    //{
        //    //    return await _mediator.Send(new GetAllBroadcastsQuery());
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return null;
        //    //}
        //}        //[HttpGet]
        //public ActionResult<IEnumerable<object>> Get(ODataQueryOptions<Broadcast> options)
        //{
        //    var defaultBroadcastTypeId = new Guid("0151059b-a859-4931-f3f2-08d773208df1");
        //    var list = new List<Broadcast>(){
        //        new Broadcast
        //        {
        //            BroadcastId = Guid.NewGuid(),
        //            Title = "NBA Finals",
        //            BroadcastTypeId = defaultBroadcastTypeId
        //        },
        //        new Broadcast
        //        {
        //            BroadcastId = Guid.NewGuid(),
        //            Title = "WCF Finals",
        //            BroadcastTypeId = defaultBroadcastTypeId
        //        },
        //    }.AsQueryable();
        //    return options.ApplyTo(list).Cast<object>().ToList();
        //    //try
        //    //{
        //    //    return await _mediator.Send(new GetAllBroadcastsQuery());
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return null;
        //    //}
        //}

        //[EnableQuery]
        //[HttpGet]
        //public Broadcast Get(int key)
        //{
        //    try
        //    {
        //        return await _mediator.Send(new GetBroadcastQuery());
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}
