using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Model;
using DataAccess;
using DataAccess.Repositories.Interface;

namespace EStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersAPI : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MembersAPI(IMemberRepository repo)
        {
            _memberRepository = repo;
        }

        //// GET: api/Members
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        //{

        //}

        // GET: api/Members/5
        [HttpGet("{id}")]
        public ActionResult<Member> GetMember(int id)
        {
            return _memberRepository.Get(id);
        }

        //// PUT: api/Members/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMember(int id, Member member)
        //{

        //}

        //// POST: api/Members
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Member>> PostMember(Member member)
        //{

        //}

        //// DELETE: api/Members/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMember(int id)
        //{

        //}

    }
}
