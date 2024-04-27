
using COMP003B.Assignment5.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DinosaursController : Controller
    {

        private List<Dinosaurs> _dinosaurs = new List<Dinosaurs>();

        public DinosaursController()
        {
            _dinosaurs.Add(new Dinosaurs { Id = 1, Name = "Tyrannosaurus Rex", Era = "Cretaceous", Diet = "Carnivore" });
            _dinosaurs.Add(new Dinosaurs { Id = 2, Name = "Velociraptor", Era = "Cretaceous", Diet = "Carnivore" });
            _dinosaurs.Add(new Dinosaurs { Id = 3, Name = "Stegosaurus", Era = "Jurassic", Diet ="Herbivore" });
            _dinosaurs.Add(new Dinosaurs { Id = 4, Name = "Triceratops", Era = "Cretaceous", Diet = "Herbivore" });
            _dinosaurs.Add(new Dinosaurs { Id = 5, Name = "Allosaurus", Era = "Jurassic", Diet = "Carnivore" });
            _dinosaurs.Add(new Dinosaurs { Id = 6, Name = "Ankylosaurus", Era = "Cretaceous", Diet = "Herbivore" });
            _dinosaurs.Add(new Dinosaurs { Id = 7, Name = "Diplodocus", Era = "Jurassic", Diet = "Herbivore" });
             


        }

        [HttpGet]
        public ActionResult<IEnumerable<Dinosaurs>> GetAllDinosaurs()
        {
            return _dinosaurs;
        }

        [HttpGet("{id}")]
        public ActionResult<Dinosaurs> GetDinosaursById(int id)
        {
            var dinoaurs = _dinosaurs.FirstOrDefault(d => d.Id == id);

            if (dinoaurs == null)
            {
                return NotFound();
            }

            return dinoaurs;
        }

        [HttpPost]
        public ActionResult<Dinosaurs> CreateDinosaurs(Dinosaurs dinosaurs)
        {
            dinosaurs.Id =_dinosaurs.Max(d => d.Id)+1;

            _dinosaurs.Add(dinosaurs);

            return CreatedAtAction(nameof(GetDinosaursById), new { id = dinosaurs.Id }, dinosaurs);
        }

        [HttpPut]
        public ActionResult<Dinosaurs> UpdateDinosaurs(int id, Dinosaurs updatedDinosaurs)
        {
            var dinosaurs = _dinosaurs.Find(d => d.Id == id);

            if(dinosaurs == null)
            {
                return BadRequest();
            }

            dinosaurs.Name = updatedDinosaurs.Name;
            dinosaurs.Era = updatedDinosaurs.Era;
            dinosaurs.Diet = updatedDinosaurs.Diet;

            return NoContent();
            
        }

        [HttpDelete]
        public ActionResult DeleteDinosaurs(int id)
        {
            var dinosaurs = _dinosaurs.Find(d => d.Id==id);

            if(dinosaurs == null)
            {
                return NotFound();
            }

            _dinosaurs.Remove(dinosaurs);
            return NoContent();
        }
    }
}
