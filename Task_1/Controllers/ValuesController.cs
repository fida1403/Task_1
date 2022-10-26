using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Task_1.Models;

namespace Task_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Connectivity_ProContext mycontext;

        public ValuesController(Connectivity_ProContext mycontext)
        {
            this.mycontext = mycontext;
        }


        [HttpGet("get")]
        public List<User> get()
            {
                var data = this.mycontext.Users.ToList();
                return data;
            }

        [HttpPost("post")]
        public string post(User rg)
        {
            String str = rg.FirstName;
            int len = str.Length;
            int i, fl=0;
            for (i = 0; i < len; i++)
            {
                if (str[i] == ' ')
                {
                    fl = 1;
                }
                else
                {
                    fl = 0;
                }
            }
            if(fl == 1)
            {
               return "should not contain whitespace";
            }
            else
            {
                this.mycontext.Add(rg);
                this.mycontext.SaveChanges();
                return "success";
            }
        }
        

            [HttpPut("put")]
            public string Put(User rg)
            {
                if (rg == null || rg.Email == null)
                {
                    return "error";
                }
                var data = this.mycontext.Users.Find(rg.Email);
                if (data == null)
                {
                    return "no data found";
                }
            String str = rg.FirstName;
            int len = str.Length;
            int i, fl = 0;
            for (i = 0; i < len; i++)
            {
                if (str[i] == ' ')
                {
                    fl = 1;
                }
                else
                {
                    fl = 0;
                }
            }
            if (fl == 1)
            {
                return "should not contain whitespace";
            }
            else
            {
                data.FirstName = rg.FirstName;
                data.LastName = rg.LastName;
                data.Email = rg.Email;
                data.Password = rg.Password;
                data.Dob = rg.Dob;
                data.Gender = rg.Gender;
                this.mycontext.SaveChanges();
                return "success";
            }
         }

            [HttpDelete("delete")]
            public string delete(string Email)
            {
                var data = this.mycontext.Users.Find(Email);
                if (data == null)
                {
                    return "no data found";
                }
                this.mycontext.Users.Remove(data);
                this.mycontext.SaveChanges();
                return "success";
            }

      
    }
}
