using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WateringService;
using WateringService.Models;

namespace WateringService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreesController : ControllerBase
    {
        private readonly WateringServiceContext _context;

        public TreesController(WateringServiceContext context)
        {
            _context = context;
            //ParseCsvFile();
        }

        // GET: api/Trees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tree>>> GetTrees()
        {
          if (_context.Trees == null)
          {
              return NotFound();
          }
            return await _context.Trees.ToListAsync();
        }

        // GET: api/Trees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tree>> GetTree(Guid id)
        {
          if (_context.Trees == null)
          {
              return NotFound();
          }
            var tree = await _context.Trees.FindAsync(id);

            if (tree == null)
            {
                return NotFound();
            }

            return tree;
        }

        // PUT: api/Trees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTree(Guid id, Tree tree)
        {
            if (id != tree.TreeId)
            {
                return BadRequest();
            }

            _context.Entry(tree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tree>> PostTree(Tree tree)
        {
          if (_context.Trees == null)
          {
              return Problem("Entity set 'WateringServiceContext.Trees'  is null.");
          }
            
            _context.Trees.Add(tree);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTree", new { id = tree.TreeId }, tree);
        }
        
        // DELETE: api/Trees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTree(Guid id)
        {
            if (_context.Trees == null)
            {
                return NotFound();
            }
            var tree = await _context.Trees.FindAsync(id);
            if (tree == null)
            {
                return NotFound();
            }

            _context.Trees.Remove(tree);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TreeExists(Guid id)
        {
            return (_context.Trees?.Any(e => e.TreeId == id)).GetValueOrDefault();
        }
        //private void ParseCsvFile()
        //{
        //    var dataFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        //    var filePath = Path.Combine(dataFolderPath, "2023Irrigation - Sheet1.csv");

        //    using (var reader = new StreamReader(filePath))
        //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {
        //        csv.Configuration.RegisterClassMap<TreeMap>();

        //        var records = csv.GetRecords<Tree>();

        //        foreach (var record in records)
        //        {
        //            record.TreeId = Guid.NewGuid();
        //            _context.Trees.Add(record);
        //        }

        //        _context.SaveChanges();
        //}
        }


    }

