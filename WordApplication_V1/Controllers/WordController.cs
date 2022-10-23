using Microsoft.AspNetCore.Mvc;
using WordApplication_V1.Context;
using WordApplication_V1.Entities;

namespace WordApplication_V1.Controllers
{
    public class WordController : Controller
    {
        private readonly WordDbContext _dbContext ;

   
        public WordController()
        {
            _dbContext = new WordDbContext();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _dbContext.Words.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult AddWord()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWord(Word word)
        {
            var wordNew=new Word()
            {
                Id = new Guid(),
                EnName = word.EnName,
                TrName = word.TrName,
                ImageUrl = word.ImageUrl
            };

            if (ModelState.IsValid)
            {
                _dbContext.Words.Add(wordNew);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Word", word);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var selectedWord = _dbContext.Words.Find(id);
            _dbContext.Words.Remove(selectedWord);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Word");
        }

        [HttpGet]
        public IActionResult Update(Guid id)
        {
            var findedWord=_dbContext.Words.Find(id);
            return View(findedWord);
        }

        [HttpPost]
        public IActionResult Update(Word word)
        {
            var findedWord = _dbContext.Words.Find(word.Id);
            findedWord.EnName = word.EnName;
            findedWord.TrName = word.TrName;
            findedWord.ImageUrl=word.ImageUrl;
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Word");
        }

    }
}
