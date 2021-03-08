using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Interface;
using BusinessLogic.Model;
using BusinessLogic.Repo;
using Newtonsoft.Json.Linq;
using System.Collections;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    public class ElectionController : ApiController
    {
        ElectionRepo repo = null;
        ElectionController()
        {
            repo = new ElectionRepo();
        }

        [HttpPost]
        [Route("api/addmember")]
        public IHttpActionResult AddMember(JObject model)
        {

            var s = JsonConvert.DeserializeObject<List<ElectionModel>>(model["models"].ToString());
            int j = 0;
            for (int i = 0; i < s.Count; i++)
            {
                j = repo.Add(s[i]);
            }
            if (j >= 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("api/listmember")]
        public IHttpActionResult ListMember()
        {
            List<ElectionModel> listmember = new List<ElectionModel>();
            listmember = repo.listMember();
            if(listmember != null)
            {
                return Ok(listmember);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("api/deletemember")]
        public IHttpActionResult DeleteMember(JObject model)
        {
            var s = JsonConvert.DeserializeObject<List<ElectionModel>>(model["models"].ToString());
            int i = repo.delete(Convert.ToInt32(s[0].e_id));
            if (i >= 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("api/updaterecord")]
        public IHttpActionResult UpdateRecord(JObject model)
        {
            ElectionModel mod = new ElectionModel();
            var s = JsonConvert.DeserializeObject<List<ElectionModel>>(model["models"].ToString());
            mod.e_id = s[0].e_id;
            mod.e_name = s[0].e_name;
            mod.e_village = s[0].e_village;
            mod.e_dist = s[0].e_dist;
            mod.e_postcode = s[0].e_postcode;
            int i = repo.update(mod);
            if (i >= 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
