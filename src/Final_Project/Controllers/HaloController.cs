﻿using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Mvc;
using Final_Project.Filters;
using Final_Project.Services;
using Final_Project.Models;
using Microsoft.AspNet.Http.Features;

namespace Final_Project.Controllers {
    [Route("[controller]")]
    [TypeFilter(typeof(ModelValidator))]
    [TypeFilter(typeof(AuthorizationFilter))]
    [TypeFilter(typeof(ExceptionHandlerFilter))]
    public class HaloController : Controller {
        private IPlayersDatabase database;

        //private ISecurityProvider security;

        //private AuthorizationFilter filter = new AuthorizationFilter();

        public HaloController(IPlayersDatabase database) {
            this.database = database;
        }

        /*
        public HaloController(IPlayersDatabase database, ISecurityProvider security) {
            this.database = database;
            this.security = security;
        }
        */
        
        [HttpGet]
        public IEnumerable<PlayerModel> Get() {
            return database.GetAll();
        }

        [HttpGet("{name}")]
        public PlayerModel Get(string name) {
            var player = database.Player(name);
            if (player == null) {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return new PlayerModel();
            }
            Response.Headers.Add("ETag", new string[] { player.ETag });
            return player;
        }

        /*
        [HttpPatch("{name}")]
        public PlayerModel Patch(string name, [FromBody]PlayerModel player) {
            var model = database.Player()
        }
        */

        [HttpPatch("{name}")]
        public PlayerModel Patch(string name, [FromBody]PlayerModel player) {
            var model = database.Player(name);
            if (model == null) {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return new PlayerModel();
            }
            var ifMatch = Request.Headers.Get("if-match");
            if (ifMatch == "\"*\"" || ifMatch == model.ETag) {
                model.SetUpdated();
                database.Set(model);
                return model;
            } else {
                Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
                return new PlayerModel();
            }
        }

        [HttpPut("{name}")]
        public PlayerModel Put(string name, [FromBody]PlayerModel player) {
            var model = database.Player(name);
            if (model == null) {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return new PlayerModel();
            }
            var ifMatch = Request.Headers.Get("if-match");
            if (ifMatch == "\"*\"" || ifMatch == model.ETag) {
                model.SetUpdated();
                database.Set(model);
                return model;
            } else {
                Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
                return new PlayerModel();
            }
        }

        [HttpPost]
        public PlayerModel Post([FromBody]PlayerModel player) {
            
            ///*
            var model = database.Add(player);
            if (model == null) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new PlayerModel();
            }
            /*
            if (player == null) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new PlayerModel();
            }
            */

            /*// TEST
            var ifMatch = Request.Headers.Get("if-match");
            if (ifMatch == "\"*\"" || ifMatch == model.ETag) {
                model.SetUpdated();
                database.Set(model);
                return model;
            } else {

            }
            *///////

            //Request.Headers.Add("")
            model.SetUpdated();
            return model;
            //*/
        }

    }
}
